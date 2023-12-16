using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    [SerializeField] private List<AudioClip> audioClips;
    private AudioSource soundSource;
    private LoadSoundAudioFromWeb loadAssetBundles;
    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        loadAssetBundles = GetComponent<LoadSoundAudioFromWeb>();
        loadAssetBundles.LoadAssetBundleFromWeb();
    }
    public void PlaySound(int audioIndex)
    {
        soundSource.PlayOneShot(audioClips[audioIndex], 1); 
    }
    public void StopSound()
    {
        soundSource.Stop();
    }
    public bool IsSoundPlaying()
    {
        return soundSource.isPlaying;
    }
}
