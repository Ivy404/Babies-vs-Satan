using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerRef = null;

    // list of gameplay sounds
    public Sound[] sounds;
    void Awake()
    {
        if (audioManagerRef == null)
        {
            audioManagerRef = this;
            DontDestroyOnLoad(this);
        }

        // Initializing gameplay sounds
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void PlaySoundWithRandomPitch(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.pitch = UnityEngine.Random.Range(0.9f, 1.3f);
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("StopSound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
