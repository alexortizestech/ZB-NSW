using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIButtonManager : MonoBehaviour 
{
    public GameObject randombutton;
    public AudioSource move;
    bool hasPlayed;
    GameObject lastSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       // randombutton = GameObject.FindObjectOfType<Button>().gameObject;
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (!hasPlayed)
            {
                move.Play();
                hasPlayed = true;
                lastSelected = EventSystem.current.currentSelectedGameObject;
            }
           if(lastSelected!= EventSystem.current.currentSelectedGameObject)
            {
                hasPlayed=false;
            }
        }/*else if(EventSystem.current.currentSelectedGameObject == null)
        {
             EventSystem.current.SetSelectedGameObject(randombutton);
        }*/
    }

   
}
