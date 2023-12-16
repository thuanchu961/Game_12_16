using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioAbstract : MonoBehaviour
{
    protected AudioSource audioSource;
    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected virtual void PlayAudio()
    {
        audioSource.loop = false;
        audioSource.Play();
    }
    protected virtual void StopAudio()
    {
        audioSource.Stop();
    }
    protected virtual void IsAudioPlaying() { }
}
