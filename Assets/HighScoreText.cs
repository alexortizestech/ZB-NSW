using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ES3.KeyExists("HighScore SpeedRun") == true && ES3.Load<float>("HighScore SpeedRun")!=0)
        {
            text.text = "Best Time: " + TimeToString(ES3.Load<float>("HighScore SpeedRun"));
        }
        else
        {
            text.text = "Best Time: 0";
        }
    }


    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        string miles = ((t * 100) % 100).ToString("f0");
        return minutes + ". " + seconds + "." + miles;
    }
}
