﻿using System.Linq;
using UnityEngine;

public class Cave : MonoBehaviour
{
    private CaveEntrance[] entrances;

    private void Awake()
    {
        entrances = GetComponentsInChildren<CaveEntrance>( true );
    }

    public void Enter( GameObject playerGameObject, string entranceIdentifier )
    {
        TurnOnCave();

        CaveEntrance entrance = entrances.First( entry => entry.identifier == entranceIdentifier );
        playerGameObject.transform.position = entrance.gameObject.transform.position;
    }

    private void TurnOnCave()
    {
        foreach ( Cave cave in FindObjectsOfType<Cave>() )
        {
            cave.gameObject.SetActive( false );
        }

        gameObject.SetActive( true );
    }
}