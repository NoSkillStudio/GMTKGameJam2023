using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISMusicSettings : MonoBehaviour
{
	[SerializeField] private Toggle toggleMusic;
	[SerializeField] private Slider sliderVolumeMusic;
    [SerializeField] private AudioMixer musicMixer;
	private float volume = 0.5f;
    private void Start()
	{
		Load();
		ValueMusic();
	}

	public void SliderMusic()
	{ 
		volume = sliderVolumeMusic.value;
		Save();
        ValueMusic();
    }

	public void ToggleMusic()
	{
		if (toggleMusic.isOn == true)  
			volume = 1;
		else
			volume = 0.0001f;
		sliderVolumeMusic.value = volume;
		Save();
        ValueMusic();
    }

	public void ValueMusic()
	{
		if (volume <= 0.0001f)
		{
			volume = 0.0001f;
			toggleMusic.isOn = false;
		}
		else
			toggleMusic.isOn = true;
		musicMixer.SetFloat("MusicVolume", (float)Math.Log10(volume) * 20f);
	}

	private void Save()
	{
		PlayerPrefs.SetFloat("MusicVolume", volume);
	}

	private void Load()
	{
		volume = PlayerPrefs.GetFloat("MusicVolume", volume);
        sliderVolumeMusic.value = volume;
    }
}