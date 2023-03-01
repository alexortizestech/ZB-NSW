using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SpriteSwap : MonoBehaviour
{
    public GameObject spriteselected, spritenormal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( EventSystem.current.currentSelectedGameObject == this.gameObject)
        {
            spriteselected.SetActive(true);
            spritenormal.SetActive(false);
        }
        else
        {
            spritenormal.SetActive(true);
            spriteselected.SetActive(false);
        }
    }
}
