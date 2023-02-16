using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Febucci.UI.Core;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public float count, count2;
    public bool stop;
    public GameObject TextInfo;
    public Scene scene;
    public string Name;
    public HasEnteredLevel HL;
    public GameObject Player;
    public GameObject gm;
    public Queue<string> sentences;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueGO;
    public GameObject Arrow;
    public AudioSource Talk;

    void Start()
    {
        Talk = GameObject.Find("SoundsPrefab").transform.Find("Talks").GetComponent<AudioSource>();
        HL = GameObject.Find("SoundManager").GetComponent<HasEnteredLevel>();
        TextInfo = GameObject.Find("TextInfo");
        
        if(ES3.Load<bool>("SpeedRunMode") == true)
        {
            Destroy(TextInfo);
        }
        scene = SceneManager.GetActiveScene();
        Name = scene.name;
        Player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager");
        sentences = new Queue<string>();
        if (Name != HL.Name)
        {
            HL.hasEntered = false;
        }
        if (HL.hasEntered == true)
        {
            Destroy(TextInfo);
       
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
       
        Talk.Play();
        sentences.Clear();

        foreach (string sentence in dialogue.senteces)
        {
            sentences.Enqueue(sentence);
        }
  
        DisplayNextSentence();
    }
    private void Update()
    {
        if (gm.GetComponent<GameManager>().gamePaused)
        {
            dialogueGO.SetActive(false);
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
        }
       
        if (sentences.Count > 0)
        {
            if (stop)
              
           
            {
                gm.GetComponent<Timer>().StopTimer();
                Player.GetComponentInChildren<AnimationScript>().SetHorizontalMovement(0, 0, 0);
                Arrow.SetActive(false);
                Player.GetComponent<Movement>().enabled = false; gm.GetComponent<Timer>().StopTimer();
                Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();

                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            }
            if (!stop)
            {
                count += 1 * Time.deltaTime;
                if (count >= 4f)
                {
                   
                        DisplayNextSentence();
                    
                   
                    count = 0;
                }
            }
        }
        else if(sentences.Count ==0 && TextInfo == null && !stop)
        {
            count2 += 1 * Time.deltaTime;
            if (count2 >= 4f)
            {

                DisplayNextSentence();


                count2 = 0;
            }
        }

      
        
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            HL.hasEntered = true;
            Destroy(dialogueGO);
            if (stop)
            {
                Arrow.SetActive(true);
                Player.GetComponent<Movement>().enabled = true;
                Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                gm.GetComponent<Timer>().ResumeTimer();
                HL.FindScene();
            }
            
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;

        }
        
    }
}
