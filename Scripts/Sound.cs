using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    public AudioClip soundFile;
    [HideInInspector] public AudioSource soundSpeaker;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;
    public bool mute;

}
