using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Rewired;
public class TextTrigger : MonoBehaviour
{
    public Player player;
    bool IsTriggered;
    public Dialogue dialogue;
    public GameObject globitoText;
    public int playerID = 0;

    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !IsTriggered)
        {
            Debug.Log("EnteredDialogue");
            if (player.GetButtonDown("Teleport"))
            {
                Debug.Log("TriggeredDialogue");
                globitoText.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                IsTriggered = true;
                Destroy(this.gameObject);
            }
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsTriggered)
        {
            IsTriggered = false;
        }
    }

}
