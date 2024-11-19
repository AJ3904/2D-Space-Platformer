using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSwitch : MonoBehaviour
{
    [SerializeField] private MovingPlatforms movingPlatforms;
    [SerializeField] private Animator animator;
    [SerializeField] private float switchTime = 5f;
    [SerializeField] private bool down = false;
    private float delta;

    void Awake()
    {
        delta = switchTime;
    }

    void Update()
    {
        if(down)
        {
            delta -= Time.deltaTime;
            if(delta <= 0)
            {
                down = false;
                movingPlatforms.active = false;
                animator.SetBool("Down", false);
                delta = switchTime;
            }
        }
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        down = true;
        movingPlatforms.active = true;
        animator.SetBool("Down", true);
    }
}
