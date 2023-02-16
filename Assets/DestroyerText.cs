using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (ES3.Load<bool>("SpeedRunMode") == true) {
            Destroy(this.gameObject);
                }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
