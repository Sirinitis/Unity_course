using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _bounceAudio; 
    [Min(0)] public float _volumeBounceAudio;

    [SerializeField] private AudioClip _dieAudio;
    [Min(0)] public float _volumeDieAudio;

    [SerializeField] private AudioClip _finishAudio; 
    [Min(0)] public float _volumeFinishAudio;

    [SerializeField] private AudioClip _platformBreakAudio; 
    [Min(0)] public float _volumePlatformBreakAudio;

    [SerializeField] private AudioClip _buttonAudio; 
    [Min(0)] public float _volumeButtonAudio;

    private AudioSource _audoiSource;

    private void Awake()
    {
        _audoiSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _audoiSource.Play();
    }
    public void ButtonAudio()
    {
        _audoiSource.PlayOneShot(_buttonAudio, _volumeButtonAudio);
    }
    public void PlatformBreakAudio()
    {
        _audoiSource.PlayOneShot(_platformBreakAudio, _volumePlatformBreakAudio);
    }
    public void BounceAudio()
    {
        _audoiSource.PlayOneShot(_bounceAudio, _volumeBounceAudio);
    }
    public void FinishAudio()
    {
        _audoiSource.PlayOneShot(_finishAudio, _volumeFinishAudio);
    }
    public void DieAudio()
    {
        _audoiSource.PlayOneShot(_dieAudio, _volumeDieAudio);
    }
}
