using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLogic : MonoBehaviour
{
    public float FadeAfterXSeconds;
    public float FadeDuration;

    private float elapsedTime;

    bool hasFinished;

    float realUpdateTime;

    private void Awake()
    {
        realUpdateTime = Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        hasFinished = false;

        PauseHandler.instance.PauseGameOnly();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFinished)
        {
            elapsedTime += realUpdateTime;

            //Hack - final day. Press interact to skip the wait
            if(Input.GetButtonDown("Interact"))
            {
                elapsedTime = FadeAfterXSeconds;
            }

            if (elapsedTime >= FadeAfterXSeconds)
            {
                StartCoroutine(Fade());
            }
            if (elapsedTime > (FadeAfterXSeconds + FadeDuration))
            {
                hasFinished = true;
                RemoveScene();
            }
        }
    }

    IEnumerator Fade()
    {
        CanvasGroup canvasGroup = GetComponentInChildren<CanvasGroup>();
        for (float ft = FadeDuration; ft >= 0; ft -= realUpdateTime)
        {
            if (canvasGroup)
            {
                canvasGroup.alpha = ft;
            }
            yield return null;
        }
    }

    void RemoveScene()
    {
        SceneManager.sceneUnloaded += TutorialOver;
        SceneManager.UnloadSceneAsync(this.gameObject.scene.name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

    static void TutorialOver(Scene s)
    {
        if (s.name == "IntroScene")
        {
            PauseHandler.instance.ResumeGameOnly();
        }
    }
}
