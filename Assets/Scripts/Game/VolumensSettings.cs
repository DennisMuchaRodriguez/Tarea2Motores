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
 

    private static VolumensSettings instance;
    public static VolumensSettings Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    private void Start()
    {

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolumen();
        }
        else
        {
            SetVolumeGeneral();
        }
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

    private void LoadVolumen()
    {
        float volume = PlayerPrefs.GetFloat("VolumeGeneral");
        VolumenSlider.value = volume;

        SetVolumeGeneral();
    }
}
