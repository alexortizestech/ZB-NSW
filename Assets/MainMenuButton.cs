using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class MainMenuButton : MonoBehaviour
{
    public TextMeshProUGUI PlayT, OptT, CreditsT;
    public GameObject selectedP, selectedO, selectedC;
    public GameObject Play, Options, Exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == Play)
        {
            PlayT.color = Color.black;
            OptT.color = Color.white;
            CreditsT.color = Color.white;
            selectedP.SetActive(true);
            selectedO.SetActive(false);
            selectedC.SetActive(false);
        }

        if (EventSystem.current.currentSelectedGameObject == Options)
        {
            PlayT.color = Color.white;
            OptT.color = Color.black;
            CreditsT.color = Color.white;
            selectedP.SetActive(false);
            selectedO.SetActive(true);
            selectedC.SetActive(false);
        }

        if (EventSystem.current.currentSelectedGameObject == Exit)
        {
            PlayT.color = Color.white;
            OptT.color = Color.white;
            CreditsT.color = Color.black;
            selectedP.SetActive(false);
            selectedO.SetActive(false);
            selectedC.SetActive(true);
        }
    }
}
