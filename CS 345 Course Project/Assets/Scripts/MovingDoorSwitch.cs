using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoorSwitch : MonoBehaviour
{
    [SerializeField]
    private MovingPlatforms movingPlatforms;
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("Down", true);
        movingPlatforms.active = true;
    }
}