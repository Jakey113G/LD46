using UnityEngine;

public class PersistentGameObject : MonoBehaviour
{
    private void Awake()
    {
        if ( FindObjectsOfType<PersistentGameObject>().Length == 1 )
        {
            DontDestroyOnLoad( this );
        }
        else
        {
            Destroy( gameObject );
        }
    }
}