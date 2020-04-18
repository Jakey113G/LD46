using JetBrains.Annotations;
using UnityEngine;
using Zenject;

public class GameManager : IGameManager
{
    [Inject( Id = "playerPrefab" ), UsedImplicitly]
    private PlayerController playerPrefab;

    [Inject, UsedImplicitly] private PlayerControllerFactory gameObjectFactory;

    [Inject]
    private void Inject()
    {
        Start();
    }

    public void Start()
    {
        Debug.Log( "game start" );
        gameObjectFactory.Create( playerPrefab );
    }

    public void GameOver()
    {
        Debug.Log( "game over" );
    }
}