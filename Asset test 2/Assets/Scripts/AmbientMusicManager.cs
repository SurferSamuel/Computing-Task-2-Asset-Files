using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusicManager : MonoBehaviour
{
    public AudioSource aMusic;

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

}