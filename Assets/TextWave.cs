using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextWave : MonoBehaviour
{
    public ProbabilitySystem Ps;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Ps.CurrentWaves + " / " + Ps.TotalWaves;
    }
}
