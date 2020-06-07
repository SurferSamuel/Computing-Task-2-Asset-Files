using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playMenuUI;
    public GameObject optionsMenuUI;
    public LevelLoader levelLoader;
    public AudioSource audioSource;

    private float originalVolume;

    void Awake()
    {
        originalVolume = audioSource.volume;
        audioSource.volume = 0f;
        StartCoroutine(FadeInAudio());
        playMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(FadeOutAudio());
        levelLoader.LoadNextLevel();
    }

    public void Quit()
    {
        Debug.Log("Game has quit...");
        Application.Quit();
    }

    IEnumerator FadeOutAudio()
    {
        float speed = originalVolume / 10;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeInAudio()
    {
        float speed = originalVolume / 10;
        while (audioSource.volume < originalVolume)
        {
            audioSource.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
