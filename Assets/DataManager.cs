using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public LevelSelector Selector;
    public GameObject Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == Button1)
        {
            Selector.Index = 4;
        }
        if (EventSystem.current.currentSelectedGameObject == Button2)
        {
            Selector.Index = 5;
        }
        if (EventSystem.current.currentSelectedGameObject == Button3)
        {
            Selector.Index = 6;
        }
        if (EventSystem.current.currentSelectedGameObject == Button4)
        {
            Selector.Index = 7;
        }
        if (EventSystem.current.currentSelectedGameObject == Button5)
        {
            Selector.Index = 8;
        }
        if (EventSystem.current.currentSelectedGameObject == Button6)
        {
            Selector.Index = 9;
        }
        if (EventSystem.current.currentSelectedGameObject == Button7)
        {
            Selector.Index = 10;
        }
        if (EventSystem.current.currentSelectedGameObject == Button8)
        {
            Selector.Index = 11;
        }
        if (EventSystem.current.currentSelectedGameObject == Button9)
        {
            Selector.Index = 14;

        }


    }
}
