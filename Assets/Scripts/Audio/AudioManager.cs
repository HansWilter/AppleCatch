using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer masterMixer = default;
    private static AudioManager instance;
    public static AudioManager Singleton { get { return instance; } }
    private AudioSource audioSource;
    // Start is called before the first frame update 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        float oldVolume = PlayerPrefs.GetFloat("PlayerSetVolume");
        masterMixer.SetFloat("volume", oldVolume);
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

}
