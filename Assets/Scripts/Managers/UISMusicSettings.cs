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
		if (toggleMusic.isOn == false)  
			volume = -80f;
		else
			volume = 0f;
		sliderVolumeMusic.value = volume;
		Save();
        ValueMusic();
    }

	public void ValueMusic()
	{
		musicMixer.SetFloat("MusicVolume", volume / 5);
		toggleMusic.isOn = volume > -80f;

		if(volume == -80f)
            musicMixer.SetFloat("MusicVolume", -80f);
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
