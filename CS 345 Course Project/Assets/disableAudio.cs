using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("bgm").GetComponent<BackgroundMusicControl>().PlayMusic();
    }
}
