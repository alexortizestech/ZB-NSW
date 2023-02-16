using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public float Timer;
    public float Speed;
    public bool RestoreTime;
    
    // Start is called before the first frame update
    void Start()
    {
        RestoreTime = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (RestoreTime)
        {
            if (Time.timeScale < 1f)
            {
                Timer += Time.deltaTime * Speed;
            }
            else
            {
                Timer = 0;
                Time.timeScale = 1f;
                RestoreTime = false;
            }
        }
        Debug.Log(Time.timeScale + " TIMESCALE");
        if (Timer >= 1)
        {
            Time.timeScale = 1;
        }
    }


    public void StopTime(float ChangeTime,int RestoreSpeed,float Delay)
    {

        Speed = RestoreSpeed;

        if (Delay > 0)
        {
            StopCoroutine(StartTimeAgain(Delay));
            StartCoroutine(StartTimeAgain(Delay));
        }
        else
        {
            RestoreTime = true;

        }
        Time.timeScale = ChangeTime;
    }


    IEnumerator StartTimeAgain(float amt)
    {
        RestoreTime = true;
        yield return new WaitForSeconds(amt);
        
    }
}
