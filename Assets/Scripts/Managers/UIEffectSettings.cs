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
        if (toggleEffect.isOn == false)
            volume = -80f;
        else
            volume = 0f;
        sliderVolumeEffect.value = volume;
        Save();
        ValueEffect();
    }

    public void ValueEffect()
    {
        effectMixer.SetFloat("EffectVolume", volume);
        toggleEffect.isOn = volume > -80f;
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