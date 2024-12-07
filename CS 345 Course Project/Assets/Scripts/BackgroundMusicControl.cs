using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicControl : MonoBehaviour
{
    private AudioSource music;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        music = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }
}
