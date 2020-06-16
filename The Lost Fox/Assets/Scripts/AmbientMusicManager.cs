using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusicManager : MonoBehaviour
{
    public AudioSource aMusic;
    private float originalVolume;

    void Start()
    {
        originalVolume = aMusic.volume;
        aMusic.volume = 0f;
        StartCoroutine(FadeInAudio());
    }

    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            aMusic.Pause();
        }
        else
        {
            aMusic.UnPause();
        }
    }

    public void NextLevelAudioTransition()
    {
        StartCoroutine(FadeOutAudio());
    }

    IEnumerator FadeOutAudio()
    {
        float speed = originalVolume / 10;
        while (aMusic.volume > 0)
        {
            aMusic.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeInAudio()
    {
        float speed = originalVolume / 10;
        while (aMusic.volume < originalVolume)
        {
            aMusic.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

}