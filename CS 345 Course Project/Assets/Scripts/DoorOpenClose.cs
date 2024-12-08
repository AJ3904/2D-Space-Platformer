using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private Animator animator;
    public PlayerController player;

    public AudioClip doorOpenClip;
    private AudioSource audioSource;
    private bool hasPlayedSound = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger area, has the key item, and hasn't played the sound already
        if (other.CompareTag("Player") && player.keyItemCollected && !hasPlayedSound)
        {
            animator.SetTrigger("Open");
            PlayDoorOpenAudio();
            hasPlayedSound = true; // Mark that the sound has been played
        }
    }

    // Method to play the door open audio clip
    void PlayDoorOpenAudio()
    {
        if (audioSource != null && doorOpenClip != null)
        {
            audioSource.PlayOneShot(doorOpenClip);
        }
    }
}
