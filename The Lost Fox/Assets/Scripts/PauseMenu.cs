using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public AudioSource audioSource;

    private float originalVolume;

    public LevelLoader levelLoader;

    void Start()
    {
        originalVolume = audioSource.volume;
        audioSource.volume = 0f;
        StartCoroutine(FadeInAudio());
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
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

    IEnumerator FadeOutAudio()
    {
        float speed = originalVolume / 10;
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= speed;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        StartCoroutine(FadeOutAudio());
        levelLoader.LoadMainMenu();
        StartCoroutine(GameIsPausedRefresh());
    }

    IEnumerator GameIsPausedRefresh()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameIsPaused = false;
    }

    public void Quit()
    {
        Debug.Log("Game has quit...");
        Application.Quit();
    }
}
