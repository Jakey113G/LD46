using UnityEngine;

public abstract class CollideActivator : MonoBehaviour
{
    public string playerTagName = "Player";

    public bool autoUse = false;
    public bool canConsume = false;

    private bool canContinueToExist = true;
    private GameObject playerGameObject;

    [SerializeField] private string uiMessage = "Press \"space\" to use";

    private void Update()
    {
        if ( canContinueToExist == false && canConsume == true )
        {
            Debug.Log( "Trigger was consumed by " + playerTagName );
            Destroy( gameObject );
        }
        else if ( playerGameObject != null && ( autoUse || Input.GetButtonDown( "Interact" ) ) )
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

            TriggerEntered( playerGameObject );
            PlayerUi.ShowInteractionPopup( uiMessage );
        }
    }

    private void OnTriggerExit2D( Collider2D other )
    {
        if ( other.CompareTag( playerTagName ) )
        {
            Debug.Log( "Trigger was left by " + playerTagName );

            TriggerExit( playerGameObject );
            PlayerUi.HideInteractionPopup();

            playerGameObject = null;
        }
    }

    /// <summary>
    /// Actual interaction logic.
    /// </summary>
    /// <returns>T</returns>
    protected abstract void Interact( GameObject playerGameObject );

    protected virtual void TriggerEntered( GameObject playerGameObject ) { }
    protected virtual void TriggerExit( GameObject playerGameObject ) { }
}