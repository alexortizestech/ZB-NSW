using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetResolution : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        Set720();
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(QualitySettings.vSyncCount == 2)
        {
            text.text = "ON";
        }else if(QualitySettings.vSyncCount == 0)
        {
            text.text = "OFF";
        }
    }

    public void Set720()
    {
        Screen.SetResolution(1280, 720, true);
    }
    public void Set1080()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void Set2K()
    {
        Screen.SetResolution(2560, 1440, true);
    }
    public void Set4k()
    {
        Screen.SetResolution(3840, 2160, true);
    }

    public void ChangeVsync()
    {
        if(QualitySettings.vSyncCount == 2)
        {
            QualitySettings.vSyncCount = 0;

        }else if(QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 2;
        }
        
    }

}
