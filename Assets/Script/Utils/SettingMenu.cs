using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float volumeValue;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    
    void Update()
    {
        audioMixer.SetFloat("volume", volumeValue);
        PlayerPrefs.SetFloat("volume", volumeValue);
    }
    // Start is called before the first frame update
    public void SetVolume(float volume)
    {
        volumeValue = volume;
    }
}
