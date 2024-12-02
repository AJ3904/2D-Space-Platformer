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

    void NextSentence()
    {
        if(index < sentences.Length)
        {
            dialogueText.text = "";
            if(index > 2)
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
        foreach(char character in sentences[index].ToCharArray())
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        index++;
        NextSentence();
    }

    void LoadTutorial()
    {
        SceneManager.LoadScene("level0");
    }   
}