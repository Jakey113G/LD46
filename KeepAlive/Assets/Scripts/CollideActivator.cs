using System;
using UnityEngine;

public class CollideActivator : MonoBehaviour
{
    public string playerTagName = "Player";
    public bool canConsume = false;
    public bool canContinueToExist = true;

    private GameObject playerGameObject;
    
    private void Update()
    {
        if ( canContinueToExist == false && canConsume == true )
        {
            Destroy( gameObject );
        }
        else if (playerGameObject != null && Input.GetKeyDown( KeyCode.Space ) )
        {
            Interact( playerGameObject );
            canContinueToExist = false;
        }
    }

    private void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.CompareTag( playerTagName ) )
        {
            Debug.Log( "Trigger was activated by " + playerTagName );
            playerGameObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D( Collider2D other )
    {
        if ( other.CompareTag( playerTagName ) )
        {
            Debug.Log( "Trigger was deactivated by " + playerTagName );
            playerGameObject = null;
        }
    }

    /// <summary>
    /// Actual interaction logic.
    /// </summary>
    /// <returns>T</returns>
    protected virtual void Interact( GameObject playerGameObject ) { }
}