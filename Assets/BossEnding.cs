using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnding : MonoBehaviour
{
    public GameObject Particles1, Particles2, Particles3, Particles4;
    // Start is called before the first frame update
    void Start()
    {
        Particles1.SetActive(true);
        Particles2.SetActive(true);
        Particles3.SetActive(true);
        Particles4.SetActive(true);
        EndingRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndingRoutine()
    {
        
        if (ES3.Load<bool>("SpeedRunMode") == false)
        {
            SceneManager.LoadScene("FinalText");

        }
        else if (ES3.Load<bool>("SpeedRunMode") == true)
        {
            SpeedRunMode Sr;
            Sr = GameObject.Find("SoundManager").GetComponent<SpeedRunMode>();
            Sr.StopTimer(); if (Sr.timer < Sr.HighScoreRun || Sr.HighScoreRun == 0)
            {
                ES3.Save("HighScore SpeedRun", Sr.timer);
                Sr.HighScoreRun = ES3.Load<float>("HighScore SpeedRun");
            }
            Destroy(Sr.timerText.gameObject);
            SceneManager.LoadScene("LevelSelector");
        }
    }
}
