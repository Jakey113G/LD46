using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashOptions : MonoBehaviour
{
    public string SceneToStartOn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(SceneToStartOn, LoadSceneMode.Single);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
