using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour
{
    public float RestartAfterXSeconds;

    private float elapsedTimer;
    bool hasTriggered;

    // Start is called before the first frame update
    void Start()
    {
        hasTriggered = false;
        elapsedTimer = 0;

        //find pause component. Pause game. - won't matter once we restart the game
        PauseHandler[] handlers = FindObjectsOfType<PauseHandler>();
        foreach (PauseHandler pause in handlers)
        {
            pause.IsPauseInteractionAllowed = false;
            pause.NotifyPauseUI = false;
            pause.IsPaused = true;
        }
    
    }

    void PrepareToRestart()
    {
        int sceneCount = SceneManager.sceneCount;
        for(int i = 0; i < sceneCount; ++i)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            SceneManager.UnloadSceneAsync(scene.name, UnloadSceneOptions.None);
        }

        //unload all scenes and load splash only
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (!hasTriggered)
        {
            elapsedTimer += Time.deltaTime;
            if (elapsedTimer >= RestartAfterXSeconds)
            {
                hasTriggered = true;
                PrepareToRestart();
            }
        }
    }
}
