using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
using UnityEngine.EventSystems;
public class CreditsCancel : MonoBehaviour
{
    public GameObject MainMenu;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("UICancel"))
        {
            MainMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
