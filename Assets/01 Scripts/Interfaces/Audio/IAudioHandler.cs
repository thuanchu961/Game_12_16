using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioHandler 
{
    public void PlayAudio(int audioIndex);
    public void StopAudio();
    public bool IsAudioPlaying();
}
