using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetAudioController : MonoBehaviour, IAudioHandler
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsAudioPlaying()
    {
        return audioSource.isPlaying;
    }

    public void PlayAudio(int audioIndex)
    {
        audioSource.loop = false;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
