using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonSelect : MonoBehaviour

{
  
   public GameObject selected;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(selected);
    }
}

