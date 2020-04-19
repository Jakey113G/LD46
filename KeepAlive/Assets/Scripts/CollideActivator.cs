using UnityEngine;

public class CollideActivator : MonoBehaviour
{
    public string playerTagName = "Player";

    public bool autoUse = false;
    public bool canConsume = false;
    
    private bool canContinueToExist = true;
    private GameObject playerGameObject;

    private void Update()
    {
        if ( canContinueToExist == false && canConsume == true )
        {
            Debug.Log( "Trigger was consumed by " + playerTagName );
            Destroy( gameObject );
        }
        else if ( playerGameObject != null && ( autoUse || Input.GetKeyDown( KeyCode.Space ) ) )
        {
            Debug.Log( "Trigger was triggered by " + playerTagName );
            Interact( playerGameObject );
            canContinueToExist = false;
        }
    }

    private void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.CompareTag( playerTagName ) )
        {
            Debug.Log( "Trigger was entered by " + playerTagName );
            playerGameObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D( Collider2D other )
    {
        if ( other.CompareTag( playerTagName ) )
        {
            Debug.Log( "Trigger was left by " + playerTagName );
            playerGameObject = null;
        }
    }

    /// <summary>
    /// Actual interaction logic.
    /// </summary>
    /// <returns>T</returns>
    protected virtual void Interact( GameObject playerGameObject ) { }
}