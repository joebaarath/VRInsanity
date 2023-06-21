using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionManager : MonoBehaviour
{

    public FadeScreen fadeScreen;
    public static int score;

    public void AddScore()
    {
        score += 1;
        Debug.Log(score);
    }
    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    public void reset()
    {
        StartCoroutine(GoToSceneRoutine(0));
    }

    public void FinalScene()
    {
        if (score > 3)
        {
            StartCoroutine(GoToSceneRoutine(3));
        }
        else
        {
            StartCoroutine(GoToSceneRoutine(4));
        }
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.gameObject.SetActive(true);
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        SceneManager.LoadScene(sceneIndex);

    }

    public void GoToSceneAsync(int sceneIndex)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    public void FinalSceneAsync()
    {
        if (score > 3)
        {
            StartCoroutine(GoToSceneAsyncRoutine(1));
        }
        else
        {
            StartCoroutine(GoToSceneAsyncRoutine(2));
        }
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        //Launch new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        float timer = 0;
        while(timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
