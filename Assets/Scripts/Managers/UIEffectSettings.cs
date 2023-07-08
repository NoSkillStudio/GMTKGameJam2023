using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIEffectSettings : MonoBehaviour
{
    [SerializeField] private Toggle toggleEffect;
    [SerializeField] private Slider sliderVolumeEffect;
    [SerializeField] private AudioMixer effectMixer;
    private float volume = 0.5f;
    private void Start()
    {
        Load();
        ValueEffect();
    }

    public void SliderEffect()
    {
        volume = sliderVolumeEffect.value;
        Save();
        ValueEffect();
    }

    public void ToggleEffect()
    {
        if (toggleEffect.isOn == true)
            volume = 1;
        else
            volume = 0.0001f;
        sliderVolumeEffect.value = volume;
        Save();
        ValueEffect();
    }

    public void ValueEffect()
    {
        if (volume <= 0.0001f)
        {
            toggleEffect.isOn = false;
            volume = 0.0001f;
        }               
        else
            toggleEffect.isOn = true;
        effectMixer.SetFloat("EffectVolume", (float)Math.Log10(volume) * 20f);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }

    private void Load()
    {
        volume = PlayerPrefs.GetFloat("EffectVolume", volume);
        sliderVolumeEffect.value = volume;
    }
}