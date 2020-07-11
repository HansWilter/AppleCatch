using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider = default;

    [SerializeField]
    private AudioMixer audioMixer = default;

    void Start()
    {
        float oldVolume = PlayerPrefs.GetFloat("PlayerSetVolume");
        volumeSlider.SetValueWithoutNotify(oldVolume);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("PlayerSetVolume", volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
