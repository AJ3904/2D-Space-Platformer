using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    private int nextLevel;
    public string levelNumber;
    public GameObject completeMenu;
    [SerializeField]
    private AudioSource backgroundMusic;

    private void Start() 
    {
        completeMenu.SetActive(false);
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        completeMenu.SetActive(true);
        Time.timeScale = 0f;
        backgroundMusic.Stop();
        Utils.SetBool(levelNumber, true);
        Utils.SetInt("levelAt", int.Parse(levelNumber));
    }

    public void LoadNextLevel()
    {
        completeMenu.SetActive(false);
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(2);
        } 
        else 
        {
            SceneManager.LoadScene(nextLevel);
            if(nextLevel > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextLevel - 1);
            }
        }
    }

    public void LoadMenu()
    {
        completeMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
