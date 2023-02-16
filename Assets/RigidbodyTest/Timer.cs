using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    private float startTime;

    bool keepTiming;
    public float timer;
    public GameManager gm;

    void Start()
    {

        gm = FindObjectOfType<GameManager>();
        StartTimer();
    }

    void Update()
    {
        if (gm.hasWon)
        {
            Debug.Log("Timer stopped at " + TimeToString(StopTimer()));
        }

        if (keepTiming)
        {
            UpdateTime();
        }
     //   PlayerPrefs.SetFloat("TIME", timer);
    }

    void UpdateTime()
    {
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer);
    }

 public   float StopTimer()
    {
        keepTiming = false;
        return timer;
    }

   public void ResumeTimer()
    {
        keepTiming = true;
        startTime = Time.time - timer;
    }

    void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        string miles = ((t*100)%100).ToString("f0");
        return minutes + ". " + seconds + "." + miles;
    }
}
