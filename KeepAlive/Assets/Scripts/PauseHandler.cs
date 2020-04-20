using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    //private float initialFixedTime;

    public bool IsPauseInteractionAllowed = true;
    public bool NotifyPauseUI = true;

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

            if (NotifyPauseUI)
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
        if (IsPauseInteractionAllowed)
        {
            IsPaused = !hasFocus;
        }
    }

    void Update()
    {
        bool pressPause = Input.GetButtonDown("Cancel");
        if (pressPause && IsPauseInteractionAllowed)
        {
            IsPaused = !isPaused;
        }
    }

    public void OnResumeGame()
    {
        IsPaused = false;
    }

    //public float GetInitialFixedTime()
    //{
    //    return initialFixedTime;
    //}
}
