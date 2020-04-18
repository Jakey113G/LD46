﻿using System;
using UnityEngine;

/**
 * This is represents the player's torch. When it's health reaches 0 the game is over.
 * Does not necessarily need to be attached to the torch game object itself.
 */
public class Torch : MonoBehaviour
{
    public event Action onHealthIsZero;

    [SerializeField] private float health = 100;
    [SerializeField] private float baseDeclineRatePerSecond = 1.0f;

    private void Update()
    {
        float delta = Time.deltaTime * baseDeclineRatePerSecond;

        health = Mathf.Max( 0, health - delta );

        if ( health <= 0 )
        {
            Debug.Log( "torch is dead" );

            enabled = false;
            onHealthIsZero?.Invoke();
        }
    }

    public void Kindle( float amount )
    {
        health += amount;

        Debug.Log( $"torch is kindled by ${amount} for a total of ${health}" );
    }
}