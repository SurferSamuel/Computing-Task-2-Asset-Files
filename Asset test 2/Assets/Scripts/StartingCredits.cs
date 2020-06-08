using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingCredits : MonoBehaviour
{
    public LevelLoader levelLoader;

    void Start()
    {
        StartCoroutine(StartMainMenu());
    }

    IEnumerator StartMainMenu()
    {
        yield return new WaitForSeconds(2f);
        levelLoader.LoadNextLevel();
    }
}
