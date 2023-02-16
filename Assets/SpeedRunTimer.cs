using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRunTimer : MonoBehaviour
{
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ES3.Load<bool>("SpeedRunMode") == true)
        {
            Text.SetActive(false);
        }
    }
}
