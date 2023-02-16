using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    public GameObject Camera;
    public float Multiplier;
    bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            if (Camera.GetComponent<Camera>().fieldOfView <= 42f)
            {
                Camera.GetComponent<Camera>().fieldOfView += Multiplier * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            triggered = true;
         
        }
    }
}
