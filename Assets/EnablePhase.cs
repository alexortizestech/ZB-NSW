using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePhase : MonoBehaviour
{
    public bool disabler;
    bool IsTriggered;
    public GameObject enable, disable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !IsTriggered)
        {
            enable.SetActive(true);
            if (disabler)
            {
                disable.SetActive(false);
            }
           // 
            IsTriggered = true;
           // Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTriggered = false;
    }
}
