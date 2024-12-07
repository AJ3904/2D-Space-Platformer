using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private Animator animator;
    public PlayerController player;

    public AudioClip doorOpenClip;
    private AudioSource doorAudioSource;

    [Range(0f, 1f)] // This makes the volume adjustable in the Unity Inspector with a slider
    public float doorAudioVolume = 0.75f; // Default volume


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        doorAudioSource = gameObject.AddComponent<AudioSource>();
        doorAudioSource.loop = false;

        // Set the volume to the manually adjustable value
        doorAudioSource.volume = doorAudioVolume;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && player.keyItemCollected)
        {
            animator.SetTrigger("Open");
            
            if (doorOpenClip != null && doorAudioSource != null)
            {
                doorAudioSource.PlayOneShot(doorOpenClip);
            }
        }
    }
}
