using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Rewired;
#if UNITY_SWITCH
using Rewired.Platforms.Switch;
#endif
public class TextTrigger : MonoBehaviour
{

   public bool IsTriggered;
    public Dialogue dialogue;
    public GameObject globitoText;
    [SerializeField] public int playerID = 0;
    [SerializeField] public Player player;

    private void Start()
    {
        playerID = 0;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !IsTriggered)
        {
            Debug.Log("EnteredDialogue");
            if (player.GetButtonDown("Slash") || Input.GetKeyDown(KeyCode.E))
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
