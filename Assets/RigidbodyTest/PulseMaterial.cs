using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseMaterial : MonoBehaviour
{
    public float emissiveIntensity;
    Color emissiveColor;
    public Material material;
    float delta;
    public float R, G, B;
   [SerializeField] public float min=0.01f, max=0.05f, t=0.05f, length=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
       // emissiveColor = GetComponent<Renderer>().material.color;
      
    }

    // Update is called once per frame
    void Update()
    {
       emissiveIntensity=Mathf.Lerp (min,max,Mathf.PingPong(t * Time.time, length));
        
        material.SetColor("_EmissionColor", new Color(R, G, B) * emissiveIntensity);
    }
}

