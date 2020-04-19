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
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
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
