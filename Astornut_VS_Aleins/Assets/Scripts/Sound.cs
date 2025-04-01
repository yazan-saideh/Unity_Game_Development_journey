using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip AudioClip;
    [Range(0, 1)]
    public float Volume;
    [Range(.3f, 3)]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public AudioSource AudioSource;
}
