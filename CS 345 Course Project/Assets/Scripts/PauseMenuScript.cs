using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    private AudioSource backgroundMusic; // Reference to the music AudioSource

    void Start()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;

        // Find the AudioSource with the "pauseMusic" tag
        GameObject musicObject = GameObject.FindWithTag("pauseMusic");
        if (musicObject != null)
        {
            backgroundMusic = musicObject.GetComponent<AudioSource>();
            // Disable play on awake so music doesn't start automatically
            backgroundMusic.playOnAwake = false;
        }
        else
        {
            Debug.LogWarning("No GameObject with the 'pauseMusic' tag found in the scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        Time.timeScale = 1f;
        isPaused = false;

        // Stop background music
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Play background music
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }
}
