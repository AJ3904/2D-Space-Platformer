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

    public AudioClip textScrollClip;
    private AudioSource textAudioSource;

    void Start()
    {
        // Initialize the audio source
        textAudioSource = gameObject.AddComponent<AudioSource>();
        textAudioSource.clip = textScrollClip;
        textAudioSource.loop = true; // Ensure the clip loops while text is being written
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
            animator.SetTrigger("Darken");
        }
    }

    IEnumerator WriteSentence()
    {
        // Start the audio when writing begins
        if (textAudioSource != null && textScrollClip != null)
        {
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

    void LoadTutorial()
    {
        SceneManager.LoadScene("level0");
    }
}
