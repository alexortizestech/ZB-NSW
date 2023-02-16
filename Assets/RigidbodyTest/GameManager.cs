using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Com.LuisPedroFonseca.ProCamera2D;
using Rewired;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    AudioListener listener;
    public AudioSource GlitchSound;
    public GameObject CanvasEnding;
    public GameObject Camera;
    public float currentTime;
    public Movement mv;
    public bool hasWon, gamePaused;
    //public TextMeshProUGUI text;
    public GameObject[] enemies;
    public Scene scene;
    public string NextScene;
    public Timer timer;
    public GameObject Player;
    public GameObject PauseMenu,OptionsMenu;
    public float HighScore;
    public int Combo;
  // [SerializeField] public float timer;
    [SerializeField] public ProCamera2D ProCam;
    bool value;
    public bool collectableTaken;
    int CollectablesValue;
    public Player player;
    public RLProGlitch2 GlitchWin;
    public GameObject PostProcessing;
    public bool isWave;
    

    // Start is called before the first frame update

    void Start()
    {
    
        listener = this.GetComponent<AudioListener>();
        GlitchSound = GameObject.Find("GlitchSound").GetComponent<AudioSource>();
        GlitchSound.Play();
        PostProcessVolume volume = PostProcessing.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out GlitchWin);
        player = ReInput.players.GetPlayer(0);
        //   CanvasEnding = GameObject.Find("CanvasEnding");
        Camera = GameObject.Find("MainCamera");
        Scene scene = SceneManager.GetActiveScene();
        if (!ES3.KeyExists("Collectables"))
        {
            ES3.Save("Collectables", 0);
        }


      
        if (ES3.KeyExists("Combo " + scene.name.ToString())==false)
        {
            Debug.Log("Does NOT Exists");
            ES3.Save("Combo " + scene.name.ToString(), Player.GetComponent<Movement>().Damage);
        }
        if (ES3.KeyExists("Best Time " + scene.name.ToString())==false)
        {
            ES3.Save<float>("Best Time " + scene.name.ToString(),0);
        }

        Combo = ES3.Load<int>("Combo " + scene.name.ToString());
        HighScore = ES3.Load<float>("Best Time " + scene.name.ToString());
        //PauseMenu = GameObject.Find("PauseMenu");
        Time.timeScale = 1;
        gamePaused = false;
        Player = GameObject.Find("Player");
        timer = this.gameObject.GetComponent<Timer>();
        hasWon = false;
       // Cursor.visible = false;
    }
   
    // Update is called once per frame
    void Update()
    {
      //  timer += 1 * Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        CollectablesValue = ES3.Load<int>("Collectables");
        Debug.Log("HIGHSCORE " + HighScore);
        Scene scene = SceneManager.GetActiveScene();
      
        if (enemies.Length == 0)
        {
            //Win();
        }
        // text.text = timer.ToString("F2") + " s";
        if (!hasWon)
        {
            currentTime = PlayerPrefs.GetFloat("TIME");
        }

        if(gamePaused==true && player.GetButtonDown("UICancel"))
        {
            Resume();
        }
        if (scene.name == "FinalBossScene")
        {
            if (Player.GetComponent<Movement>().Wingame == true)
            {
                if (timer.timer < HighScore || HighScore == 0)
                {
                    ES3.Save("Best Time " + scene.name.ToString(), timer.timer);
                    HighScore = ES3.Load<float>("Best Time " + scene.name.ToString());


                }

              
            }
        }
          
        if (hasWon)
        {
            if (player.GetButtonDown("Jump"))
            {
                StartCoroutine(WinRoutine());
            }

           
        }
        Debug.Log("current time: " + currentTime);

        if (Player.GetComponent<Movement>().Damage > Combo || Combo == 0)
        {
            ES3.Save("Combo " + scene.name.ToString(), Player.GetComponent<Movement>().Damage);
            Combo = ES3.Load<int>("Combo " + scene.name.ToString());
        }
          
    }


    public void Pause()
    {

        Debug.Log("Pause");
        mv.enabled = false;
        PauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(PauseMenu.transform.Find("Resume").gameObject);
        gamePaused = true;
        Time.timeScale = 0;
       // Cursor.visible = true;
    }

    public void Resume()
    {
        if (OptionsMenu.activeInHierarchy)
        {
            OptionsMenu.SetActive(false);
        }
        Time.timeScale = 1;
        mv.enabled = true;
        PauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        gamePaused = false;
        //Cursor.visible = false;
    }
    public void Win()
    {
        Debug.Log("WIN EXECUTING");
        listener.enabled = true;
        
        Scene scene = SceneManager.GetActiveScene();
        value = true;
        ES3.Save("Passed " + scene.name.ToString(), true);
        timer.StopTimer();
        hasWon = true;
        if (collectableTaken)
        {
            ES3.Save("Taken" + scene.name.ToString(), true);
            ES3.Save("Collectables", CollectablesValue + 1);
        }
        if (timer.timer < HighScore || HighScore==0)
        {
            ES3.Save("Best Time " + scene.name.ToString(), timer.timer);
            HighScore = ES3.Load<float>("Best Time " + scene.name.ToString());
            
        }
        if (scene.name == "FinalBossScene")
        {
            ES3.Save("GameComplete", true);
            StartCoroutine(WinRoutine());
        }
        
        if (ES3.Load<bool>("SpeedRunMode") == false && scene.name != "FinalBossScene")
        {
            StartCoroutine(CameraFinal());
        }
       

        if (ES3.Load<bool>("SpeedRunMode") == true)
        {
            Destroy(Player);
            StartCoroutine(WinRoutine());
        }
        FindObjectOfType<SaveGame>().SavePlayerPrefs();
    }


    public void GameOver()
    {


        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        //ProCam.enabled = false;
        yield return new WaitForSeconds(1f);
      //  timer = timer;
        Debug.Log("Game Over");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }


    IEnumerator WinRoutine()
    {
        GlitchSound.Play();
        Scene scene = SceneManager.GetActiveScene();
        // Destroy(Player);
        // mv.enabled = false;
        GlitchWin.enabled.value = true;
        yield return new WaitForSeconds(2f);
        // timer = timer;
       
        SceneManager.LoadScene(scene.buildIndex + 1);
        Debug.Log("You Win");
    }

    [System.Obsolete]
    IEnumerator CameraFinal()
    {
        Destroy(Player);
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z - 11);
        this.gameObject.GetComponent<Timer>().timerText.gameObject.SetActive(false);
        Camera.GetComponent<ProCamera2D>().RemoveAllCameraTargets(0);
        Camera.GetComponent<ProCamera2D>().AddCameraTarget(Player.GetComponent<Movement>().door.transform, 1, 1, 0);
        Camera.GetComponent<ProCamera2DCameraWindow>().CameraWindowRect.height = 0.2f;
        Camera.GetComponent<ProCamera2DCameraWindow>().CameraWindowRect.width = 0.11f;
        yield return new WaitForSeconds(1f);
        Camera.GetComponent<Camera>().fieldOfView = 5;
       
        CanvasEnding.SetActive(true);
     
        CanvasEnding.transform.Find("HighScoreEnd").GetComponent<TextMeshProUGUI>().text = "HighScore: " + TimeToString(HighScore);
        CanvasEnding.transform.Find("Current").GetComponent<TextMeshProUGUI>().text = "Current Score: " + TimeToString(timer.timer);
        CanvasEnding.transform.Find("Combo").GetComponent<TextMeshProUGUI>().text = "Best Combo: " + Combo;
      


        yield return new WaitForSeconds(2F);
      /*  if(ES3.KeyExists("Taken" + scene.name.ToString()))
        {
            if (ES3.Load<bool>("Taken" + scene.name.ToString()) == true)
            {
                CanvasEnding.transform.Find("CollectableSprite").GetComponent<RawImage>().enabled = true;
            }
        }*/
       
        // StartCoroutine(WinRoutine());
        
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        string miles = ((t * 100) % 100).ToString("f0");
        return minutes + ". " + seconds + "." + miles;
    }
}
