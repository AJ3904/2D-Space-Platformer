using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AnimatedText : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    public Animator animator;
    private int index = 0;
    [SerializeField]
    private float dialogueSpeed = 0.01f;

    public AudioClip textScrollClip; // Audio during text scroll
    public AudioClip countdownEndClip; // Audio when countdown stops

    private AudioSource textAudioSource;

    void Start()
    {
        // Initialize the audio source
        textAudioSource = gameObject.AddComponent<AudioSource>();
        textAudioSource.loop = false; // Ensure it doesn't loop
        textAudioSource.playOnAwake = false; // Prevent audio from playing immediately
    }

    void NextSentence()
    {
        if (index < sentences.Length)
        {
            dialogueText.text = "";
            if (index > 2)
            {
                dialogueText.text = "Brace for impact in ";
                dialogueSpeed = 1f;
            }
            StartCoroutine(WriteSentence());
        }
        else
        {
            StartCoroutine(PlayCountdownEndAndTriggerAnimation());
        }
    }

    IEnumerator WriteSentence()
    {
        // Start the audio when writing begins
        if (textAudioSource != null && textScrollClip != null)
        {
            textAudioSource.clip = textScrollClip;
            textAudioSource.Play();
        }

        foreach (char character in sentences[index].ToCharArray())
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(dialogueSpeed);
        }

        // Stop the audio when writing ends
        if (textAudioSource != null)
        {
            textAudioSource.Stop();
        }

        index++;
        NextSentence();
    }

    IEnumerator PlayCountdownEndAndTriggerAnimation()
    {
        // Play the countdown end clip
        if (countdownEndClip != null && textAudioSource != null)
        {
            textAudioSource.clip = countdownEndClip;
            textAudioSource.Play();

            animator.SetTrigger("Darken");
            // Wait for the audio clip to finish before continuing
            yield return new WaitForSeconds(textAudioSource.clip.length);
        }
    }

    public void LoadTutorial() // Called by the animation event or other triggers
    {
        SceneManager.LoadScene("level0");
    }
}
