using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    [SerializeField]
    public string bgmName;

    public AudioSource musicSource;

    public static AudioManager Instance;

    bool isPlayed;

    void Awake()
    {
        Instance = this;

        foreach (Sound s in sounds)
        {
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (!isPlayed)
        {
            PlayBGM(bgmName);
            isPlayed = true;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log(s.name);
        s.source.PlayOneShot(s.clip);
    }

    public void PlayBGM(string bgmName)
    {
        musicSource.Stop();
        Sound s = Array.Find(sounds, sound => sound.name == bgmName);
        musicSource.clip = s.clip;
        musicSource.Play();
    }
}