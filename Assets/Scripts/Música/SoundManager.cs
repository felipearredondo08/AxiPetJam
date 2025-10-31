using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public string song = "musica acuario";

    private bool _isPlaying = true;
    private bool _isSilence = false;

    public static SoundManager soundManager;

    void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroy SM");
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumen;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        FindFirstObjectByType<SoundManager>().Play(song);
    }

    public void Change(string name)
    {
        Stop(song);
        Play(name);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }

        s.source.Stop();
    }

    public void SwitchActiveMusic(string musicName)
    {
        Sound s = Array.Find(sounds, sound => sound.name ==  musicName);
        _isPlaying = !_isPlaying;
        if (_isPlaying)
        {
            s.source.volume = 1;
        }
        else
        {
            s.source.volume = 0;
        }
    }


    public void SwitchActiveSounds()
    {
        _isSilence = !_isSilence;
        foreach (Sound s in sounds)
        {
            if (_isSilence)
            {
                s.source.volume = 0;
            }
            else
            {
                s.source.volume = 1;
            }
        }
    }
}