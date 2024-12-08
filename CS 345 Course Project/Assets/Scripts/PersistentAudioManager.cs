using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuAudioManager : MonoBehaviour
{
    private static PauseMenuAudioManager instance; // Singleton instance
    private AudioSource audioSource;

    public AudioClip pauseMenuMusicClip; // Assign your music clip in the Inspector

    void Awake()
    {
        // Singleton pattern: Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            InitializeAudioSource();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    private void InitializeAudioSource()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = pauseMenuMusicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false; // Start playback manually
        audioSource.volume = 0.5f; // Set volume if needed
        audioSource.Play(); // Start playing music
    }

    public void PauseMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
    }

    public void ResumeMusic()
    {
        if (!audioSource.isPlaying)
            audioSource.UnPause();
    }
}
