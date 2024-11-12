using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityTimer : MonoBehaviour
{

    private float timeForNextSwitch;
    public float zeroGravityDuration = 5.0f;
    public bool isZeroGravity = false;

    // Start is called before the first frame update
    void Start()
    {
        timeForNextSwitch = Time.time + zeroGravityDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeForNextSwitch)
        {
            isZeroGravity = !isZeroGravity;
            timeForNextSwitch = Time.time + zeroGravityDuration;
        }
    }
}
