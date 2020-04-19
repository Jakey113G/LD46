using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashOptions : MonoBehaviour
{
    [SerializeField]
    private string sceneToStartOn;

    public void Awake()
    {
        //Make sure game any global mutators are reset for fresh game.
        Time.timeScale = 1.0f;
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneToStartOn, LoadSceneMode.Single);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
