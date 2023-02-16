using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerManager : MonoBehaviour
{
    public string ThisScene;
    public new AudioSource audio;
    public AudioClip Menu, Scene01, Scene02, Scene03, Scene04, Scene05, Scene06,Scene07,Scene08,FinalBossScene,Transicion;
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 30;
        audio = GetComponent<AudioSource>();

        ThisScene = SceneManager.GetActiveScene().name;
        if (ThisScene == "MainMenuScene")
        {
            audio.Stop();
            audio.clip = Menu;
            audio.Play();
        }else if (ThisScene == "LabScene")
        {
            audio.Stop();
           
        }
        else if (ThisScene == "Scene01")
        {
            audio.Stop();
            audio.clip = Scene01;
            audio.Play();
        }
        else if (ThisScene == "Scene02")
        {
            audio.Stop();
            audio.clip = Scene02;
            audio.Play();
        }
        else if (ThisScene == "Scene03")
        {
            audio.Stop();
            audio.clip = Scene03;
            audio.Play();
        }
        else if (ThisScene == "Scene04")
        {
            audio.Stop();
            audio.clip = Scene04;
            audio.Play();
        }
        else if (ThisScene == "Scene05")
        {
            audio.Stop();
            audio.clip = Scene05;
            audio.Play();
        }
        else if (ThisScene == "Scene06")
        {
            audio.Stop();
            audio.clip = Scene06;
            audio.Play();
        }
        else if (ThisScene == "Scene07")
        {
            audio.Stop();
            audio.clip = Scene07;
            audio.Play();
        }
        else if (ThisScene == "Scene08")
        {
            audio.Stop();
            audio.clip = Scene08;
            audio.Play();
        }
        else if (ThisScene == "FinalBossScene")
        {
            audio.Stop();
            audio.clip = FinalBossScene;
            audio.Play();
        }
        else if (ThisScene == "TransicionScene")
        {
            audio.Stop();
            audio.clip = Transicion;
            audio.Play();
        }
        else if (ThisScene == "CreditsScene")
        {
            audio.Stop();

        }
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music"); if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Application.targetFrameRate = 30;
        ThisScene = SceneManager.GetActiveScene().name;
        if (ThisScene == "MainMenuScene" && audio.clip!=Menu)
        {
            audio.Stop();
            audio.clip = Menu;
            audio.Play();
        }
        else if (ThisScene == "LabScene")
        {
            audio.Stop();

        }
        else if (ThisScene == "Scene01" && audio.clip != Scene01)
        {
            audio.Stop();
            audio.clip = Scene01;
            audio.Play();
        }
        else if (ThisScene == "Scene02" && audio.clip != Scene02)
        {
            audio.Stop();
            audio.clip = Scene02;
            audio.Play();
        }
        else if (ThisScene == "Scene03" && audio.clip != Scene03)
        {
            audio.Stop();
            audio.clip = Scene03;
            audio.Play();
        }
        else if (ThisScene == "Scene04" && audio.clip != Scene04)
        {
            audio.Stop();
            audio.clip = Scene04;
            audio.Play();
        }
        else if (ThisScene == "Scene05" && audio.clip != Scene05)
        {
            audio.Stop();
            audio.clip = Scene05;
            audio.Play();
        }
        else if (ThisScene == "Scene06" && audio.clip != Scene06)
        {
            audio.Stop();
            audio.clip = Scene06;
            audio.Play();
        }
        else if (ThisScene == "Scene07" && audio.clip != Scene07)
        {
            audio.Stop();
            audio.clip = Scene07;
            audio.Play();
        }
        else if (ThisScene == "Scene08" && audio.clip != Scene08)
        {
            audio.Stop();
            audio.clip = Scene08;
            audio.Play();
        }
        else if (ThisScene == "FinalBossScene" && audio.clip != FinalBossScene)
        {
            audio.Stop();
            audio.clip = FinalBossScene;
            audio.Play();
        }
        else if (ThisScene == "TransicionScene" && audio.clip != Transicion)
        {
            audio.Stop();
            audio.clip = Transicion;
            audio.Play();
        }
        else if (ThisScene == "CreditsScene")
        {
            audio.Stop();

        }
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
    private void Start()
    {
        ThisScene = SceneManager.GetActiveScene().name;
        if (ThisScene == "MainMenuScene")
        {
            audio.Stop();
            audio.clip = Menu;
            audio.Play();
        }
        else if (ThisScene == "LabScene")
        {
            audio.Stop();

        }
        else if (ThisScene == "Scene01")
        {
            audio.Stop();
            audio.clip = Scene01;
            audio.Play();
        }
        else if (ThisScene == "Scene02")
        {
            audio.Stop();
            audio.clip = Scene02;
            audio.Play();
        }
        else if (ThisScene == "Scene03")
        {
            audio.Stop();
            audio.clip = Scene03;
            audio.Play();
        }
        else if (ThisScene == "Scene04")
        {
            audio.Stop();
            audio.clip = Scene04;
            audio.Play();
        }
        else if (ThisScene == "Scene05")
        {
            audio.Stop();
            audio.clip = Scene05;
            audio.Play();
        }
        else if (ThisScene == "Scene06")
        {
            audio.Stop();
            audio.clip = Scene06;
            audio.Play();
        }
        else if (ThisScene == "Scene07")
        {
            audio.Stop();
            audio.clip = Scene07;
            audio.Play();
        }
        else if (ThisScene == "Scene08")
        {
            audio.Stop();
            audio.clip = Scene08;
            audio.Play();
        }
        else if (ThisScene == "FinalBossScene")
        {
            audio.Stop();
            audio.clip = FinalBossScene;
            audio.Play();
        }
        else if (ThisScene == "TransicionScene")
        {
            audio.Stop();
            audio.clip = Transicion;
            audio.Play();
        }
        else if (ThisScene == "CreditsScene")
        {
            audio.Stop();

        }
    }
    void Update()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }
   
}


// Update is called once per frame

