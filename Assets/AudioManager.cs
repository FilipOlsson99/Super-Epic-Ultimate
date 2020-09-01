using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public Sound[] sounds;

    void Awake() {
        foreach (Sound s in sounds)

        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.CLip;

            s.source.volume = s.pitch;
            s.source.pitch = s.pitch;

        }
    }

    void Start()
    {
        Play("Theme");
    }


   public void Play (string name)
    {
        //Debug.Log(name);
      // Sound s = Array.Find(sounds, sound => sound.name == name);
        //s.source.Play();
    }
}
