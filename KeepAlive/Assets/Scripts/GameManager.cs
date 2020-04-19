using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private Transform playerStart;

    public void Start()
    {
        Debug.Log( "game start" );
        Instantiate( playerPrefab, playerStart.position, playerStart.rotation );
    }

    public void GameOver()
    {
        Debug.Log( "game over" );
    }
}