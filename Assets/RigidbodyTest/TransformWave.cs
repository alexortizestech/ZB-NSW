using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformWave : MonoBehaviour
{
    //  public ParticleSystem particles;
    public GameObject audioPulse;
    public CircleCollider2D cc;
    public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        audioPulse = GameObject.Find("PulseSound");
        audioPulse.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //  ParticleSystem.ShapeModule ps = particles.GetComponent<ParticleSystem>().shape;
        //ps.radius = cc.radius;
        circle.transform.localScale = new Vector3( cc.radius,cc.radius,cc.radius);
    }
}
