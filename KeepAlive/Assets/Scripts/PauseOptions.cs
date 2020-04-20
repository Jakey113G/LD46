using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOptions : MonoBehaviour
{
    void Start()
    {
        SetVisibility(false);
    }

    public void OnPauseChanged(bool pauseStatus)
    {
        SetVisibility(pauseStatus);
    }

    //Methods bound to UI
    public void ResumeGame()
    {
        PauseHandler handler = this.GetComponent<PauseHandler>();
        if (handler)
        {
            handler.OnResumeGame();
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    //helper method
    private void SetVisibility(bool state)
    {
        GetComponent<Canvas>().enabled = state;
    }
}
