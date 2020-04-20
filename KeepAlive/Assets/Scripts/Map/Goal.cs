using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : CollideActivator
{
    public bool allowInteraction = true;

    protected override void Interact( GameObject playerGameObject )
    {
        if (allowInteraction)
        {
            //Only allow one-shot
            allowInteraction = false;

            //Scene will handle restart and pause
            SceneManager.LoadSceneAsync("SurvivorSplash", LoadSceneMode.Additive);
        }
    }
}