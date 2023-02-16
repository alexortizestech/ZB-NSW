using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    Scene scene;
    public bool isAttacking;
    public GameManager gm;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            // gm.Win();
            ES3.Save<bool>("Passed " + scene.name, true);
           
        }

    }
}
