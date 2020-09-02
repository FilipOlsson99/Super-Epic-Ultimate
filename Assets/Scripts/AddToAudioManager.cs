using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToAudioManager : MonoBehaviour
{

    void Start()
    {
        GetComponentInParent<AudioManagerDemo>().audioSources.Add(GetComponent<AudioSource>());
    }

}
