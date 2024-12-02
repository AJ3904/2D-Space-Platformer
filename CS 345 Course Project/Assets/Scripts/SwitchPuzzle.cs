using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzle : MonoBehaviour
{
    [SerializeField]
    private SwitchPuzzleSwitches[] switchPuzzleSwitches;
    [SerializeField]
    private MovingPlatforms movingPlatforms;
    [SerializeField]
    private Animator[] lightAnimator;
    public List<int> keysPressed;
    private readonly int[] passcode = { 3, 2, 4, 1 };
    private bool puzzleSolved;

    void Start()
    {
        keysPressed = new List<int>();
        puzzleSolved = false;
    }

    // Call this method when a switch is pressed
    public void AddKey(int key)
    {
        if (puzzleSolved) return; // No further input if already solved
        
        keysPressed.Add(key);

        // Check current keys against the passcode
        if(!IsSequenceValid())
        {
            ResetPuzzle();
            return;
        }

        // If the sequence is correct and matches passcode length
        if (keysPressed.Count == passcode.Length)
        {
            ActivateMovingPlatforms();
        }
    }

    private bool IsSequenceValid()
    {
        for (int i = 0; i < keysPressed.Count; i++)
        {
            if (keysPressed[i] != passcode[i])
            {
                return false; // Mismatch found
            }
            lightAnimator[i].SetBool("On", true);
        }
        return true; // Sequence matches so far
    }

    private void ResetPuzzle()
    {
        keysPressed.Clear();
        foreach (SwitchPuzzleSwitches puzzleSwitch in switchPuzzleSwitches)
        {
            puzzleSwitch.deactivateSwitch();
        }
        foreach (Animator animator in lightAnimator)
        {
            animator.SetBool("On", false);
        }
    }

    private void ActivateMovingPlatforms()
    {
        puzzleSolved = true;
        movingPlatforms.active = true;
    }
}