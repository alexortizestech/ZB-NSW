using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collectable : MonoBehaviour
{
    bool isTaken;
    public Scene scene;
    int CollectablesValue;
    public GameObject audioCollectable;
    public GameObject GameManager;
    public GameObject Sprite;// Start is called before the first frame update
    void Start()
    {
        audioCollectable = GameObject.Find("audioCollectable");
        GameManager = GameObject.Find("GameManager");
        scene = SceneManager.GetActiveScene();
        if (!ES3.KeyExists("Taken" + scene.name.ToString()))
        {
            ES3.Save("Taken" + scene.name.ToString(), false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        isTaken = ES3.Load<bool>("Taken" + scene.name.ToString());
        if (isTaken)
        {
            Sprite.SetActive(true);
            Destroy(this.gameObject);
        }

        Debug.Log("Coleccionables " + ES3.Load<int>("Collectables"));
        Debug.Log("Coleccionable Taken" + ES3.Load<bool>("Taken" + scene.name.ToString()));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioCollectable.GetComponent<AudioSource>().Play();
            GameManager.GetComponent<GameManager>().collectableTaken = true;
            Sprite.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
