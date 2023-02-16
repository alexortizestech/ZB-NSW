using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ES3.Save<bool>("Start", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
