using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipss { biggunfire, robothit, pistol, robotdeath, reload, spawn, robotgun, health, bodyhit, Button  };

public class AudioManagerDemo : MonoBehaviour
{
    public static AudioManagerDemo instance;

    [SerializeField] AudioClip[] biggunfire;
    [SerializeField] AudioClip[] robothit;
    [SerializeField] AudioClip[] pistol;
    [SerializeField] AudioClip[] robotdeath;
    [SerializeField] AudioClip[] reload;
    [SerializeField] AudioClip[] spawn;
    [SerializeField] AudioClip[] robotgun;
    [SerializeField] AudioClip[] health;
    [SerializeField] AudioClip[] bodyhit;
    [SerializeField] AudioClip[] Button;



    public List<AudioSource> audioSources = new List<AudioSource>();

    public AudioSource musicsource;
    public AudioClip menumusic;
    public AudioClip gamemusic;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void PlayMenuMusic()
    {
        musicsource.clip = menumusic;
        musicsource.Play();
        

    }

    public void PlayGameMusic()
    {
        musicsource.clip = gamemusic;
        musicsource.Play();

    }

    private int GetNonPlayingAudioSource()
    {
        for(int i = 0; i < audioSources.Count; i++)
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
            case AudioClipss.biggunfire:
                audioSources[i].clip = biggunfire[0];
                audioSources[i].Play();
                break;
            case AudioClipss.robothit:
                audioSources[i].clip = robothit[0];
                audioSources[i].Play();
                break;
            case AudioClipss.pistol:
                audioSources[i].clip = pistol[0];
                audioSources[i].Play();
                break;
            case AudioClipss.robotdeath:
                audioSources[i].clip = robotdeath[0];
                audioSources[i].Play();
                break;
            case AudioClipss.reload:
                audioSources[i].clip = reload[0];
                audioSources[i].Play();
                break;
            case AudioClipss.spawn:
                audioSources[i].clip = spawn[0];
                audioSources[i].Play();
                break;
            case AudioClipss.robotgun:
                audioSources[i].clip = robotgun[0];
                audioSources[i].Play();
                break;
            case AudioClipss.health:
                audioSources[i].clip = health[0];
                audioSources[i].Play();
                break;
            case AudioClipss.bodyhit:
                audioSources[i].clip = bodyhit[0];
                audioSources[i].Play();
                break;
            case AudioClipss.Button:
                audioSources[i].clip = Button[0];
                audioSources[i].Play();
                break;
        }
    }

    


}
