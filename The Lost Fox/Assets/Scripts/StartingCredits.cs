using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingCredits : MonoBehaviour
{
    public LevelLoader levelLoader;

    void Start()
    {
        StartCoroutine(StartNextLevel());
    }

    IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(3f);
        levelLoader.LoadNextLevel();
    }
}
