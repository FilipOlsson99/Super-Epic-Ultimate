using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class EndTimes : MonoBehaviour
{

    public Text timeCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeSpan timePlaying = TimeSpan.FromSeconds(TimerController.instance.elaspedTime);
        string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
        timeCounter.text = timePlayingStr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
