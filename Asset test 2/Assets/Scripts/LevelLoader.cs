using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Crossfade Trigger");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMain(1));
    }

    IEnumerator LoadMain(int levelIndex)
    {
        transition.updateMode = AnimatorUpdateMode.UnscaledTime;
        transition.SetTrigger("Crossfade Trigger");
        yield return new WaitForSecondsRealtime(transitionTime);
        transition.updateMode = AnimatorUpdateMode.Normal;
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1f;
    }
}
