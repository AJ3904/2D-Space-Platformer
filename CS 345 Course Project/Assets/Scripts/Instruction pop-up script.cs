using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionUI : MonoBehaviour
{
    public string levelNumber;
    [SerializeField]
    private GameObject instruction;
    // Start is called before the first frame update
    void Start()
    {
        if(!Utils.GetBool(levelNumber)){
            Time.timeScale = 0f;
        }
        else {
            instruction.SetActive(false);
        }
    }

    public void closeWindow()
    {
        Time.timeScale = 1f;
        instruction.SetActive(false);
    }
}
