using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    public TimeSpan timePlaying;
    public bool timerGoing;

    public float elaspedTime;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "00:00:00";
        timerGoing = false;
        BeginTimer();
    }

    private void OnEnable()
    {
        timerGoing = true;
        StartCoroutine(UpdateTimer());
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elaspedTime = 0f;

        StartCoroutine(UpdateTimer());

    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elaspedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elaspedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            yield return null;
    
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
