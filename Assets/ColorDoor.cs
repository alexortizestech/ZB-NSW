using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDoor : MonoBehaviour
{
    public GameObject CloneParticles, Particles;
    public int DoorLife;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DoorLife == 1)
        {
            mat.SetColor("_EmissionColor", Color.yellow);
            mat.color = Color.yellow;
        }else if (DoorLife == 2)
        {
            mat.SetColor("_EmissionColor", Color.red);
            mat.color = Color.red;
        }
        else if (DoorLife == 3)
        {
            mat.SetColor("_EmissionColor", Color.magenta);
            mat.color = Color.magenta;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Movement>().Damage >= DoorLife && collision.GetComponent<Movement>().DashTimeCounter>=0)
            {
                collision.GetComponent<Movement>().CountSlash = 1;
                
                collision.GetComponent<Movement>().Damage = 1;
                CloneParticles = Instantiate(Particles, transform.position, transform.rotation);
                Destroy(CloneParticles, 2f);
                Destroy(this.gameObject);
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Movement>().Damage >= DoorLife && collision.GetComponent<Movement>().DashTimeCounter >= 0)
            {
                collision.GetComponent<Movement>().CountSlash = 1;

                collision.GetComponent<Movement>().Damage = 1;
                CloneParticles = Instantiate(Particles, transform.position, transform.rotation);
                Destroy(CloneParticles, 2f);
                Destroy(this.gameObject);

            }
        }
    }
}
