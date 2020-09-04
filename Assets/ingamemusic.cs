using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingamemusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!AudioManagerDemo.instance.musicsource.isPlaying)
        {
            AudioManagerDemo.instance.PlayGameMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
