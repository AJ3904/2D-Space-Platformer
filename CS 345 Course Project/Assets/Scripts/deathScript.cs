using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;
    public GameObject GameOverUI;

    void Start()
    {
        GameOverUI.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartLevel()
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
