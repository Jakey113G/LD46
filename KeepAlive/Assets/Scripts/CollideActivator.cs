using UnityEngine;

public class CollideActivator : MonoBehaviour
{
    public string playerTagName = "Player";
    public bool canConsume = false;
    public bool canContinueToExist = true;

    private void Update()
    {
        if ( canContinueToExist == false && canConsume == true )
        {
            Destroy( this.gameObject );
        }
    }

    private void OnTriggerStay2D( Collider2D other )
    {
        if ( other.tag == playerTagName && Input.GetAxis( "Jump" ) > 0 )
        {
            Debug.Log( "Trigger was Activated by " + playerTagName );

            Interact( other.gameObject );
            canContinueToExist = false;
        }
    }

    /// <summary>
    /// Actual interaction logic.
    /// </summary>
    /// <returns>T</returns>
    protected virtual void Interact( GameObject playerGameObject ) { }
}