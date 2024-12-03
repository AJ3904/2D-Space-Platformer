using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    private int nextLevel;
    public string levelNumber;
    private void Start() 
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
}
