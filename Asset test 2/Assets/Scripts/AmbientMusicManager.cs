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
            aMusic.pitch = .75f;
        }
        else
        {
            aMusic.pitch = 1f;
        }
    }
}