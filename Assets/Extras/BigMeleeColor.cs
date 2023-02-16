using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeleeColor : MonoBehaviour
{

    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<EnemyBehaviour>().Health == 2)
        {
            Debug.Log("FULL HEALTH");
            mat.SetFloat("Vector1_4EFFB852", 1);
          
        }
        if (this.GetComponent<EnemyBehaviour>().Health == 1)
        {
           
            mat.SetFloat("Vector1_4EFFB852", 5);
            Debug.Log("MIN HEALTH");
            mat.SetColor("yellow",Color.yellow);
        }


    }
}
