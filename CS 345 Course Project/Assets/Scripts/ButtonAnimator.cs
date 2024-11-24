using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour
{
    private Button button;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.interactable == true)
        {
            animator.SetBool("Unlocked", true);
        }
    }
}
