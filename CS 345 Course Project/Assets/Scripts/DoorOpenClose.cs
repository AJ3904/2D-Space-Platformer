using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private Animator animator;
    public PlayerController player;

     public AudioClip doorOpenClip;
    private AudioSource doorAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorAudioSource = gameObject.AddComponent<AudioSource>();
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
