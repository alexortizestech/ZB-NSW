using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public GameObject canvas;
    public SpeedRunMode sr;
    bool Run;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ES3.Load<bool>("SpeedRunMode")==true)
        {
            canvas.SetActive(true);
            sr.enabled = true;
            if (sr.keepTiming == false)
            {
                sr.StartTimer();
            }
            
        }
        else if (ES3.Load<bool>("SpeedRunMode") == false)
        {
            canvas.SetActive(false);
            sr.enabled = false;
            sr.StopTimer();
            sr.timer = 0;
           
        }
    }


    public void SetRunMode()
    {
        ES3.Save<bool>("SpeedRunMode", true);
        
        sr.StartTimer();
    }

    public void SetNormalMode()
    {
        Debug.Log("CALLING NORMAL");
        ES3.Save<bool>("SpeedRunMode", false);
    }
}
