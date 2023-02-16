using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.EventSystems;
using Rewired.Utils;
namespace Rewired.UI.ControlMapper
{


public class CancelManagerMain : MonoBehaviour
{
    Player player;
    public GameObject Options, Controls,Main;
    public GameObject OptionsBt, ControlsBt;
    public GameObject models;
    public ControlMapper control;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Options.activeInHierarchy)
        {
            models.SetActive(false);
            if (player.GetButtonDown("UICancel"))
            {
                models.SetActive(true);
                Options.SetActive(false);
                Main.SetActive(true);
                EventSystem.current.SetSelectedGameObject(OptionsBt);
            }
        }

        if (Controls.activeInHierarchy)
        {
            
            models.SetActive(false);
            if (player.GetButtonDown("UICancel"))
            {   control.Close(false);
                models.SetActive(true);
                Controls.SetActive(false);
                Main.SetActive(true);
                EventSystem.current.SetSelectedGameObject(ControlsBt);
            }
        }



    }

        public void ClearData()
        {
            ES3.DeleteFile();
        }
}
}
