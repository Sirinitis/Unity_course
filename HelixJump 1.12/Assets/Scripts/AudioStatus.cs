using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioStatus
{
    public static bool _IsAudioOn { get; private set; } = true;

    public static void ChangeVolumeAudio() 
    {
        if (_IsAudioOn)
        {
            AudioListener.volume = 0f;
            _IsAudioOn = false;
        }
        else
        {
            AudioListener.volume = 1f;
            _IsAudioOn = true;
        }
    }
    public static void CheckSoundMatch()
    {
        if (_IsAudioOn)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0f;
    }
}
