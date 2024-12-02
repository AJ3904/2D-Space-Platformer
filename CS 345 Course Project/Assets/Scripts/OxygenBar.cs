using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OxygenBar : MonoBehaviour
{
    private float maxOxygen = 150f;
    public float currentOxygen;
    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = maxOxygen;
        InvokeRepeating("loseOxygen", 1f, 1f);
    }

    void Update()
    {
        if(currentOxygen <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void loseOxygen()
    {
        currentOxygen -= 1;
    }
}
