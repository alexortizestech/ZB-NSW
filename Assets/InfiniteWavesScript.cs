using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfiniteWavesScript : MonoBehaviour
{
    public GameObject FloorSpawner3, FloorSpawner4;
    public GameObject Arrow3, Arrow4;
    public float RecordWaves;
    public TextMeshProUGUI text;
    public ProbabilitySystem ps;
    // Start is called before the first frame update
    void Start()
    {
        if (ES3.KeyExists("MaxWaves"))
        {
            RecordWaves = ES3.Load<float>("MaxWaves");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ps.TotalWaves += 1;
        text.text = ps.CurrentWaves + "/";

        if (ps.CurrentWaves > RecordWaves || RecordWaves==0)
        {
            ES3.Save("MaxWaves", ps.CurrentWaves);
            RecordWaves = ES3.Load<float>("MaxWaves");
        }

        if (ps.CurrentWaves >= 9)
        {
            FloorSpawner3.SetActive(true);
            FloorSpawner4.SetActive(true);
        }

        if (ps.CurrentWaves >= 14)
        {
            Arrow3.SetActive(true);
            Arrow4.SetActive(true);
        }


    }
}
