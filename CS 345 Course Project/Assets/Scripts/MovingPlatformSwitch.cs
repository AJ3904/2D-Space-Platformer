using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformSwitch : MonoBehaviour
{
    [SerializeField]
    private MovingPlatforms movingPlatforms;
    [SerializeField]
    private Animator animator;

    void OnTriggerStay2D(Collider2D other)
    {
        animator.SetBool("Down", true);
        movingPlatforms.active = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Down", false);
        movingPlatforms.active = false;
    }
}
