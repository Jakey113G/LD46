using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class MappedSceneLoadState
{
    public string SceneName;

    [HideInInspector]
    public bool IsLoaded;
}

public class UILoader : MonoBehaviour
{
    [SerializeField]
    public MappedSceneLoadState[] UIScenes;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        foreach (MappedSceneLoadState mappedScene in UIScenes)
        {
            mappedScene.IsLoaded = false;
            SceneManager.LoadSceneAsync(mappedScene.SceneName, LoadSceneMode.Additive);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (MappedSceneLoadState mappedScene in UIScenes)
        {
            if (scene.name == mappedScene.SceneName)
            {
                mappedScene.IsLoaded = true;
            }
        }
    }
}
