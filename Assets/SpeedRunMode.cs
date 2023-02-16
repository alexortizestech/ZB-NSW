using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpeedRunMode : MonoBehaviour
{
    public float currentScore, HighScoreRun;
    GameObject gm;
    public TextMeshProUGUI timerText;
    private float startTime;
    public Scene scene;
    public bool keepTiming;
    public float timer;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
      
        gm = GameObject.Find("GameManager");
        
        scene = SceneManager.GetActiveScene();

        if(ES3.KeyExists("HighScore SpeedRun") == false)
        {
            ES3.Save<float>("HighScore SpeedRun",0);
        }
        HighScoreRun = ES3.Load<float>("HighScore SpeedRun");
        
        
            
        
            
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ES3.KeyExists("SpeedRunMode") && ES3.Load<bool>("SpeedRunMode") == true)
        {
            
            if (keepTiming)
            {
                UpdateTime();
            }

            if (scene.name == "FinalBossScene")
            {
                Player=GameObject.Find("Player");
                
                    if (Player.GetComponent<Movement>().Wingame == true)
                    {
                        StopTimer();
                    if (timer < HighScoreRun || HighScoreRun == 0)
                    {
                        ES3.Save("HighScore SpeedRun", timer);
                        HighScoreRun = ES3.Load<float>("HighScore SpeedRun");
                    }
                }
                
                   
            }
        }
    }
    

   
   public void UpdateTime()
    {
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer);
    }

    public float StopTimer()
    {
        keepTiming = false;
        return timer;
    }

    public void ResumeTimer()
    {
        keepTiming = true;
        startTime = Time.time - timer;
    }

    public void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        string miles = ((t * 100) % 100).ToString("f0");
        return minutes + ". " + seconds + "." + miles;
    }
}
