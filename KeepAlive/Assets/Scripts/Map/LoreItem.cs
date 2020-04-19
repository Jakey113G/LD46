using UnityEngine;

public class LoreItem : CollideActivator
{
    [SerializeField] private string loreText;

    private bool isOpen = false;

    protected override void Interact( GameObject playerGameObject )
    {
        isOpen = !isOpen;

        if ( isOpen )
        {
            PlayerUi.ShowLorePopup( loreText );
        }
        else
        {
            PlayerUi.HideLorePopup();
        }
    }

    protected override void TriggerExit( GameObject playerGameObject )
    {
        base.TriggerExit( playerGameObject );

        if ( isOpen )
        {
            PlayerUi.HideLorePopup();
            isOpen = false;
        }
    }
}