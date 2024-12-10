using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    void Start()
    {
        int levelAt = Utils.GetInt("levelAt");
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
