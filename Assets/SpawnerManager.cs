using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject Spawner2, Spawner3, Swpawner4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 2f)
        {
            Spawner2.SetActive(true);
        }else if(Time.timeSinceLevelLoad >= 1.25f)
        {
            Spawner3.SetActive(true);
        }else if(Time.timeSinceLevelLoad >= 0.5f)
        {
            Swpawner4.SetActive(true);
        }
    }
}
