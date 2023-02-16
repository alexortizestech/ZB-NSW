using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecameInvisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameVisible()
    {
        enabled = true;
    }
    private void OnBecamInvisible()
    {
        enabled = false;
    }
    
}
