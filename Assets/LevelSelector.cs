using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int Index;
    public GameObject Prefab;
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI HighScoreText;
    public GameObject Coll03, Coll04, Coll06, Coll07, Coll08,NotTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string scene = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(Index));

        if (ES3.KeyExists("Best Time " + scene))
        {
            Debug.Log(ES3.Load<float>("Best Time " + scene));
            HighScoreText.text = ("Fastest Run: " +TimeToString(ES3.Load<float>("Best Time " + scene)));
        }
        else
        {
            HighScoreText.text = ("Fastest Run: " + "__");

        }
           
        if (ES3.KeyExists("Combo " + scene))
        {
            Debug.Log(ES3.Load<int>("Combo " + scene));
            ComboText.text=( "Best Combo: x"+ (ES3.Load<int>("Combo " + scene).ToString()));
        }
        else
        {
            ComboText.text = ("Best Combo: x" + "0");
        }
            
        if (ES3.KeyExists("Passed " + scene))
        {
            Debug.Log(ES3.Load<bool>("Passed " + scene));
            if(ES3.Load<bool>("Passed " + scene) == false)
            {
                Prefab.SetActive(false);
            }else if(ES3.Load<bool>("Passed " + scene) == true)
            {
                Prefab.SetActive(true);
            }
        }

        if (!ES3.KeyExists("Passed " + scene))
        {
            Prefab.SetActive(false);
        }

            if (ES3.KeyExists("Taken" + scene))
            {
                 Debug.Log(ES3.Load<bool>("Taken" + scene));
                if(ES3.Load<bool>("Taken" + scene) == true)
            {
                NotTaken.SetActive(false);
                if (Index == 6)
                {
                    Coll03.SetActive(true);
                }
                else
                {
                    Coll03.SetActive(false);
                }

                if (Index == 7)
                {
                    Coll04.SetActive(true);
                }
                else
                {
                    Coll04.SetActive(false);
                }

                if (Index == 9)
                {
                    
                    Coll06.SetActive(true);
                }
                else
                {
                    Coll06.SetActive(false);
                }

                if (Index == 10)
                {
                    
                    Coll07.SetActive(true);
                }
                else
                {
                    Coll07.SetActive(false);
                }

                if (Index == 11)
                {
                    
                    Coll08.SetActive(true);
                }
                else
                {
                    Coll08.SetActive(false);
                }
                }
                    else if (ES3.Load<bool>("Taken" + scene) == false)
                    {
                
                if (Index == 6)
                {
                    NotTaken.SetActive(true);
                    Coll03.SetActive(false);
                    Coll04.SetActive(false);
                    Coll06.SetActive(false);
                    Coll07.SetActive(false);
                    Coll08.SetActive(false);
                }
                if (Index == 7)
                {
                    NotTaken.SetActive(true);
                    Coll03.SetActive(false);
                    Coll04.SetActive(false);
                    Coll06.SetActive(false);
                    Coll07.SetActive(false);
                    Coll08.SetActive(false);
                }
                if (Index == 9)
                {
                    NotTaken.SetActive(true);
                    Coll03.SetActive(false);
                    Coll04.SetActive(false);
                    Coll06.SetActive(false);
                    Coll07.SetActive(false);
                    Coll08.SetActive(false);
                }
                if (Index == 10)
                {
                    NotTaken.SetActive(true);
                    Coll03.SetActive(false);
                    Coll04.SetActive(false);
                    Coll06.SetActive(false);
                    Coll07.SetActive(false);
                    Coll08.SetActive(false);
                }

                if (Index == 11)
                {
                    NotTaken.SetActive(true);
                    Coll03.SetActive(false);
                    Coll04.SetActive(false);
                    Coll06.SetActive(false);
                    Coll07.SetActive(false);
                    Coll08.SetActive(false);
                }
            }

            }
        else
        {
            NotTaken.SetActive(false);
            Coll03.SetActive(false);
            Coll04.SetActive(false);
            Coll06.SetActive(false);
            Coll07.SetActive(false);
            Coll08.SetActive(false);
        }
       
            
        
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        string miles = ((t * 100) % 100).ToString("f0");
        return minutes + ". " + seconds + "." + miles;
    }
}
