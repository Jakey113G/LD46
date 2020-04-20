using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    //private float initialFixedTime;

    private bool isPauseInteractionAllowed = true;
    private bool notifyPauseUI = true;

    public static PauseHandler instance => FindObjectOfType<PauseHandler>();

    private bool isPaused;
    public bool IsPaused
    {
        get { return isPaused; }
        set
        {
            isPaused = value;

            //update time scale based on new pause state
            Time.timeScale = isPaused ? 0 : 1;
            //Time.fixedDeltaTime = initialFixedTime * Time.timeScale;

            if (notifyPauseUI)
            {
                PauseOptions options = GetComponent<PauseOptions>();
                if (options)
                {
                    options.OnPauseChanged(isPaused);
                }
            }
        }
    }

    private void Awake()
    {
        //initialFixedTime = Time.fixedDeltaTime;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (isPauseInteractionAllowed)
        {
            IsPaused = !hasFocus;
        }
    }

    void Update()
    {
        bool pressPause = Input.GetButtonDown("Cancel");
        if (pressPause && isPauseInteractionAllowed)
        {
            IsPaused = !isPaused;
        }
    }

    public void OnResumeGame()
    {
        IsPaused = false;
    }

    public void PauseGameOnly()
    {
        isPauseInteractionAllowed = false;
        notifyPauseUI = false;
        IsPaused = true;
    }

    public void ResumeGameOnly()
    {
        isPauseInteractionAllowed = true;
        notifyPauseUI = true;
        IsPaused = false;
    }

    //public float GetInitialFixedTime()
    //{
    //    return initialFixedTime;
    //}
}
