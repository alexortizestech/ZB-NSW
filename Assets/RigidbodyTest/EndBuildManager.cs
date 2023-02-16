using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class EndBuildManager : MonoBehaviour
{
    [SerializeField] public int playerID = 0;
    [SerializeField] public Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerID = 0;
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetAnyButton())
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
