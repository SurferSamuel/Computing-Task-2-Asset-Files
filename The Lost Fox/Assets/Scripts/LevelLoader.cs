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
        if (levelIndex > 6)
        {
            transition.SetTrigger("Crossfade Trigger");
            yield return new WaitForSecondsRealtime(transitionTime);
            SceneManager.LoadScene(2);
        }
        else
        {
            transition.SetTrigger("Crossfade Trigger");
            yield return new WaitForSecondsRealtime(transitionTime);
            SceneManager.LoadScene(levelIndex);
        }
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMain(2));
    }

    IEnumerator LoadMain(int levelIndex)
    { 
        transition.updateMode = AnimatorUpdateMode.UnscaledTime;
        transition.SetTrigger("Crossfade Trigger");
        yield return new WaitForSecondsRealtime(transitionTime);
        transition.updateMode = AnimatorUpdateMode.Normal;
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelIndex);
        
    }
}
