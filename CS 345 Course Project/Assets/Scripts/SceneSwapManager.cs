using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if(!Utils.GetBool("0")) {
            Utils.SetBool("0", false);
        }

        if(!Utils.GetBool("1")) {
            Utils.SetBool("1", false);
        }

        if(!Utils.GetBool("2")) {
            Utils.SetBool("2", false);
        }

        if(!Utils.GetBool("3")) {
            Utils.SetBool("3", false);
        }
    }
}
