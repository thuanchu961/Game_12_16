using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Object = UnityEngine.Object;

public class MusicController : Singleton<MusicController>
{
    [SerializeField] private List<AudioClip> audioClips;
    private AudioSource musicSource;
    private LoadMusicAudioFromWeb loadAssetBundles;
    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        loadAssetBundles = GetComponent<LoadMusicAudioFromWeb>();
        loadAssetBundles.LoadAssetBundleFromWeb();
    }

    public void PlayMusic(int audioIndex)
    {
        musicSource.clip = audioClips[audioIndex];
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public bool IsMusicPlaying()
    {
        return musicSource.isPlaying;
    }
}
