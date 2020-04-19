using System;
using TMPro;
using UnityEngine;

public class CollideActivatorUI : MonoBehaviour
{
    private static CollideActivatorUI collideActivatorUiInstance;

    public static CollideActivatorUI CollideActivatorUiInstance
    {
        get
        {
            if ( collideActivatorUiInstance == null )
            {
                collideActivatorUiInstance = FindObjectOfType<CollideActivatorUI>();
            }

            return collideActivatorUiInstance;
        }
    }

    public void Show( string text )
    {
        CollideActivatorUiInstance.gameObject.SetActive( true );
        CollideActivatorUiInstance.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void Hide()
    {
        CollideActivatorUiInstance.gameObject.SetActive( false );
    }

    private void Awake()
    {
        Hide();
    }
}