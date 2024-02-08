using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }
}
