using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuLoader : MonoBehaviour
{
    [SerializeField]
    private string pauseMenuScene;

    private bool pauseReadyToInvoke;
    private void Awake()
    {
        SceneManager.LoadSceneAsync(pauseMenuScene, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == pauseMenuScene)
        {
            pauseReadyToInvoke = true;
        }
    }
}
