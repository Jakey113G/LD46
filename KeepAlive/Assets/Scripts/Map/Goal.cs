using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : CollideActivator
{
    protected override void Interact( GameObject playerGameObject )
    {
        base.Interact( playerGameObject );

        SceneManager.LoadSceneAsync( "SurvivorSplash", LoadSceneMode.Single );
    }
}