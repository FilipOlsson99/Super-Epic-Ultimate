using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipss { gunSound, fartSound };

public class AudioManagerDemo : MonoBehaviour
{
    public static AudioManagerDemo instance;

    [SerializeField] AudioClip[] gunSound;
    [SerializeField] AudioClip[] fartSound;

    public List<AudioSource> audioSources = new List<AudioSource>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int GetNonPlayingAudioSource()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return i;
            }
        }
        return 0;
    }

    public void PlaySound(AudioClipss clipType)
    {
        int i = GetNonPlayingAudioSource();

        switch (clipType)
        {
            case AudioClipss.fartSound:
                audioSources[i].clip = fartSound[0];
                audioSources[i].Play();
                break;
            case AudioClipss.gunSound:
                audioSources[i].clip = gunSound[0];
                audioSources[i].Play();
                break;
        }
    }

    private void Update()
    {
        PlaySound(AudioClipss.fartSound);
    }


}
