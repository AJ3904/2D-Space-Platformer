using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzleSwitches : MonoBehaviour
{
    [SerializeField]
    private SwitchPuzzle switchPuzzle;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private int switchNumber;
    private bool pressed = false;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!pressed)
        {
            switchPuzzle.AddKey(switchNumber);
            animator.SetBool("Down", true);
            pressed = true;
        }
    }

    public void deactivateSwitch()
    {
        animator.SetBool("Down", false);
        pressed = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (pressed) // Only reset if the switch was pressed
        {
            animator.SetBool("Down", false); // Reset animation
            pressed = false; // Mark as unpressed
        }
    }
}
