using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextTrigger : MonoBehaviour
{
    bool IsTriggered;
    public Dialogue dialogue;
    public GameObject globitoText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !IsTriggered)
        {
            globitoText.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            IsTriggered = true;
            Destroy(this.gameObject);
        }
    }

}
