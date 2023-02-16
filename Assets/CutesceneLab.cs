using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutesceneLab : MonoBehaviour
{
    public Movement mv;
    public GameObject hair, jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 25.5f)
        {
            mv.enabled = true;
            hair.SetActive(true);
            jump.SetActive(true);
            bool StartGame;
           
        }
    }
}
