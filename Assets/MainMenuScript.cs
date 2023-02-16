using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<bool>("Start", true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ES3.Save<bool>("SpeedRunMode", false);
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
