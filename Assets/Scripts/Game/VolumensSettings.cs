using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumensSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider VolumenSlider;
    [SerializeField] private Button muteButton;

    private bool isMuted = false;

    private void Start()
    {
        LoadVolumen();
    }

    public void SetVolumeGeneral()
    {
        float volume = VolumenSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("VolumeGeneral", volume);

        musicSlider.value = volume;
        SFXSlider.value = volume;
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        float volume = isMuted ? -80f : PlayerPrefs.GetFloat("VolumeGeneral", 0.5f);
        myMixer.SetFloat("Music", isMuted ? -80f : Mathf.Log10(volume) * 20);
        myMixer.SetFloat("SFX", isMuted ? -80f : Mathf.Log10(volume) * 20);
    }

    private void LoadVolumen()
    {
        float volume = PlayerPrefs.GetFloat("VolumeGeneral", 0.5f);
        VolumenSlider.value = volume;

        SetVolumeGeneral();
    }
}
