using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravityTimer : MonoBehaviour
{
    private float timeForNextSwitch;
    public float reversedGravityDuration = 5.0f;
    public PlayerController player;

    void Start()
    {
        timeForNextSwitch = 0f;
    }
    void Update()
    {
        timeForNextSwitch += Time.deltaTime;
        if(timeForNextSwitch >= reversedGravityDuration) {
            ReverseGravityOfObjects();
            reversedGravityDuration = Random.Range(4.0f, 6.0f);
            timeForNextSwitch -= reversedGravityDuration;
        }
    }

    void ReverseGravityOfObjects()
    {
        player.ReverseGravity();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("movable");
        foreach(GameObject item in objects)
        {
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            rb.gravityScale *= -1;
        }
    }
}
