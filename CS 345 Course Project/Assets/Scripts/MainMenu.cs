using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HitPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelOne()
    {
        HitPlay();
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void ExitGame()
    {
        Debug.Log("Pressed Exit");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadAnimation()
    {
        if(Utils.GetBool("0"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            SceneManager.LoadScene(6);
        }
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(2);
    }
}
