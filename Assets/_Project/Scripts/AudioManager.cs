using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonPersistent<AudioManager> {
    [SerializeField] private AudioSource _musicSource;
    [Header("Sound")]
    [SerializeField] private AudioSource _highlightButtonSFX;
    [SerializeField] private AudioSource _pressButtonSFX;

    public void PlayHighlightButtonSFX() {
        _highlightButtonSFX.Play();
    }

    public void PlayPressButtonSFX() {
        _pressButtonSFX.Play();
    }

    public void PlayMusic(AudioClip clip) {
        _musicSource.clip = clip;
        _musicSource.Play();
    }
    public void PlayMusic(AudioClip clip, float volume) {
        _musicSource.clip = clip;
        _musicSource.volume = volume;
        _musicSource.Play();
    }

}
