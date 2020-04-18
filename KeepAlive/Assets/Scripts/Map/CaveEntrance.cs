using UnityEngine;

public class CaveEntrance : CollideActivator
{
    /**
     * Unique(ish) identifier for this entrance. Should match up with the cave entrance of the cave being entered.
     */
    [SerializeField] private string entranceIdentifier;

    [SerializeField] private Cave cave;

    public string identifier => entranceIdentifier;

    protected override void Interact( GameObject playerGameObject )
    {
        base.Interact( playerGameObject );

        if ( cave != null )
        {
            cave.Enter( playerGameObject, entranceIdentifier );
        }
    }
}