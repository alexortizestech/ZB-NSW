using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInstruction : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Button != null)
        {
            if (Enemy1 == null)
            {
                Destroy(Button);
            }
        }
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Button.SetActive(false);
        }
    }

  

}
