using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HasEnteredLevel : MonoBehaviour
{
    public GameObject Textinfo;
    public bool hasEntered;
    public Scene scene;
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        
       FindScene();
       
    }

    // Update is called once per frame
    void Update()
    {
        Textinfo = GameObject.Find("TextInfo");
        if (Textinfo == null)
        {
            hasEntered = true;
        }
        else
        {
            hasEntered = false;
        }
    }

    public void FindScene()
    {
        scene = SceneManager.GetActiveScene();
        Name = scene.name;
    }
}
