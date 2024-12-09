using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    private int nextLevel;
    public string levelNumber;
    public GameObject completeMenu;

    private void Start() 
    {
        completeMenu.SetActive(false);
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        completeMenu.SetActive(true);
        Time.timeScale = 0f;
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        completeMenu.SetActive(false);
        Time.timeScale = 1f;
        Utils.SetBool(levelNumber, true);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(1);
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
