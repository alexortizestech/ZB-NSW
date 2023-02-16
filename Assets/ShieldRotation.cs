using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotation : MonoBehaviour
{
    public EnemyBehaviour eb;
    public float speed;
    public Material Shield;
    public float Dissolve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed*Time.deltaTime, Space.Self);

        if (eb.Health == 2)
        {
            Shield.SetFloat("Vector1_D2ABD07E", 0.01f);
        } else if (eb.Health == 1)
        {
            Dissolve += Time.deltaTime;
            Shield.SetFloat("Vector1_D2ABD07E",Dissolve );
        }
    }
}
