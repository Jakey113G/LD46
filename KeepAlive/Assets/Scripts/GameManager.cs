using UnityEngine;

public class GameManager : IGameManager
{
    public void Start()
    {
        Debug.Log( "game start" );
    }

    public void GameOver()
    {
        Debug.Log( "game over" );
    }
}