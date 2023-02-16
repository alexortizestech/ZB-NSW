using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxWaveText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ES3.KeyExists("MaxWaves") == true && ES3.Load<float>("MaxWaves") != 0)
        {
            text.text = "Best Score: " + ES3.Load<float>("MaxWaves") + " Waves";
        }
        else
        {
            text.text = "Best Score: 0 Waves";
        }
    }
}
