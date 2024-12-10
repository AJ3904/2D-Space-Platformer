using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private static Music musicInstance;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);

        if(musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update() {
        AudioSource audioSource = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            audioSource.Stop();
        }
        else
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
