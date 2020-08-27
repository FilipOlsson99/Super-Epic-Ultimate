using UnityEngine.Audio;
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

    // Update is called once per framesdfsf
    void Update()
    {
        
    }
}
