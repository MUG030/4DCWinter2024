using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;
    private int previousScore;

    void Start()
    {
        previousScore = GameManager.instance.score;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.instance.score != previousScore)
        {
            if (GameManager.instance.score == 0 && audioSource.clip != clips[0])
            {
                audioSource.clip = clips[0];
                audioSource.Play();
            }
            else if (GameManager.instance.score == 200 && audioSource.clip != clips[1])
            {
                audioSource.clip = clips[1];
                audioSource.Play();
                audioSource.volume = 0.66f;
            }
            else if (GameManager.instance.score == 300 && audioSource.clip != clips[2])
            {
                audioSource.clip = clips[2];
                audioSource.Play();
                audioSource.volume = 0.55f;
            }
            previousScore = GameManager.instance.score;
        }
    }
}
