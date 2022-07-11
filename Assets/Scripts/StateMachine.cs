using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    [SerializeField] Animator animator;
    public AudioSource audioSource;
    public AudioClip jamalIntro;
    public AudioClip[] jamalVoiceClipsA;
    public AudioClip[] jamalVoiceClipsB;

    public GameObject mic;
    public GameObject option1;
    public GameObject option2;
    public GameObject option1Button;
    public GameObject option2Button;
    public GameObject introDescription;

    private int state;
    private bool isPlaying = false;

    public string[] option1Text;
    public string[] option2Text;

    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            //enable intro
            introDescription.SetActive(true);
            mic.SetActive(false);
            option1Button.SetActive(false);
            option2Button.SetActive(false);
        }
        else if (state > 0 && state < jamalVoiceClipsA.Length)
        {
            introDescription.SetActive(false);

            //play Jamal's audio
            if (isPlaying && state == 1)
            {
                audioSource.PlayOneShot(jamalIntro, 1f);
                isPlaying = false;
            }
            if (isPlaying && state < 5)
            {
                audioSource.PlayOneShot(jamalVoiceClipsA[state - 2], 1f);
                isPlaying = false;
            }

            //update options
            option1.GetComponent<Text>().text = option1Text[state-1];
            option2.GetComponent<Text>().text = option2Text[state-1];
            option1Button.SetActive(true);
            option2Button.SetActive(true);
            
        }
        else if (state > 4)
        {
            if (isPlaying)
            {
                audioSource.PlayOneShot(jamalVoiceClipsA[state - 2], 1f);
                isPlaying = false;
            }
        }

        //play annimation
        animationTriggers();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state += 1;
            isPlaying = true;
            //Debug.Log(state);
        }
    }

    void animationTriggers()
    {
        if (state == 1)
        {
            animator.SetBool("isTalking", true);
        }
        if (state == 2)
        {
            animator.SetBool("isTalking", false);
            animator.SetBool("isTired", true);
        }
        if (state == 3)
        {
            animator.SetBool("isTired", false);
            animator.SetBool("isBangingFist", true);
        }
        if (state == 4)
        {
            animator.SetBool("isBangingFist", false);
            animator.SetBool("isHandsInHead", true);
        }
        if (state == 5)
        {
            animator.SetBool("isHandsInHead", false);
            animator.SetBool("isAnguishing", true);
        }
        if (state == 6)
        {
            animator.SetBool("isAnguishing", false);
        }
    }
}
