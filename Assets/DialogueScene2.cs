using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScene2 : MonoBehaviour
{
    public GameObject FirstEnemy, TextTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstEnemy == null)
        {
            TextTrigger.SetActive(true);
        }
    }
}
