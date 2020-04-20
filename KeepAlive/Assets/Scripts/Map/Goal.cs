using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : CollideActivator
{
    public bool allowInteraction = true;

    [SerializeField] private GameObject brazierFlame;
    [SerializeField] private GameObject sparkles;

    private void Awake()
    {
        brazierFlame.SetActive( false );
        sparkles.SetActive( true );
    }

    protected override void Interact( GameObject playerGameObject )
    {
        if ( allowInteraction )
        {
            //Only allow one-shot
            allowInteraction = false;

            brazierFlame.SetActive( true );
            sparkles.SetActive( false );

            //Scene will handle restart and pause
            SceneManager.LoadSceneAsync( "SurvivorSplash", LoadSceneMode.Additive );
        }
    }
}