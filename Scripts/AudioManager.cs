using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    [SerializeField] List<Sound> sounds;
    private AudioSource audioSrc;

    private static AudioManager _instance = null;
    public static AudioManager Instance
    {
        get
        {
            if(!_instance)
            {
                _instance = FindObjectOfType<AudioManager>();
                if(!_instance)
                {
                    GameObject go = new GameObject("_AudioManager");
                    go.AddComponent<AudioManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

	void Start () {

        foreach (var sound in sounds)
        {
            sound.soundSpeaker = gameObject.AddComponent<AudioSource>();
            sound.soundSpeaker.clip = sound.soundFile;
            sound.volume = sound.soundSpeaker.volume;
            sound.loop = sound.soundSpeaker.loop;
            sound.mute = sound.soundSpeaker.mute;
        }

        PlaySound("main_theme", true, 0.5f);

	}
	
	public void PlaySound(string soundName)
    {
        foreach (var sound in sounds)
        {
            if(soundName == sound.soundFile.name)
            {
                sound.soundSpeaker.Play();
            }
        }
    }

    public void PlaySound(string soundName, bool isLoop)
    {
        foreach (var sound in sounds)
        {
            if (soundName == sound.soundFile.name)
            {
                sound.soundSpeaker.Play();
                sound.soundSpeaker.loop = isLoop;
            }
        }
    }

    public void PlaySound(string soundName, float volume)
    {
        foreach (var sound in sounds)
        {
            if (soundName == sound.soundFile.name)
            {
                sound.soundSpeaker.Play();
                sound.soundSpeaker.volume = volume;
            }
        }
    }

    public void PlaySound(string soundName, bool isLoop, float volume)
    {
        foreach (var sound in sounds)
        {
            if (soundName == sound.soundFile.name)
            {
                sound.soundSpeaker.Play();
                sound.soundSpeaker.loop = isLoop;
                sound.soundSpeaker.volume = volume;
            }
        }
    }

    public void Mute()
    {
        foreach (var sound in sounds)
        {
            sound.mute = !sound.mute;
            AudioListener.pause = sound.mute;
        }
    }

    
}
