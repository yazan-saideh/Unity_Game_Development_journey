using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.AudioClip;
            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.pitch;
            s.AudioSource.loop = s.loop;
        }
    }
    private void Start()
    {
        Play("song");
    }
    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.AudioSource.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.AudioSource.Stop();
    }
}
