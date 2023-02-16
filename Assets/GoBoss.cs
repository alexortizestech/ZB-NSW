using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ES3.Load<bool>("SpeedRunMode") == false)
            {
                SceneManager.LoadScene("FinalBossCutscene");

            }else if (ES3.Load<bool>("SpeedRunMode") == true)
            {
                SceneManager.LoadScene("FinalBossScene");
            }



        }
    }
}
