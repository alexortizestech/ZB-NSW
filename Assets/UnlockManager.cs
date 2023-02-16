using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    public GameObject C2,C3,C4,C5,C6,C7,C8,C9;
    public GameObject B2,B3,B4,B5,B6,B7,B8,B9;
    public GameObject Energy01, Energy02, Energy03, Energy04, Energy05, Energy06, Energy07, Energy08;
    public Material Box02, Box03, Box04, Box05, Box06, Box07, Box08, Box09;
    public Color Color02,Color03, Color04, Color05, Color06, Color07, Color08, Color09;

    public GameObject ButtonWave, ButtonSpeed, Candado1, Candado2;
    // Start is called before the first frame update
    void Start()
    {
        Color02 = Energy01.GetComponent<SpriteRenderer>().color;
        Box02.DisableKeyword("_EMISSION");
        Color03 = Energy02.GetComponent<SpriteRenderer>().color;
        Box03.DisableKeyword("_EMISSION");
        Color04 = Energy03.GetComponent<SpriteRenderer>().color;
        Box04.DisableKeyword("_EMISSION");
        Color05 = Energy04.GetComponent<SpriteRenderer>().color;
        Box05.DisableKeyword("_EMISSION");
        Color06 = Energy05.GetComponent<SpriteRenderer>().color;
        Box06.DisableKeyword("_EMISSION");
        Color07 = Energy06.GetComponent<SpriteRenderer>().color;
        Box07.DisableKeyword("_EMISSION");
        Color08 = Energy07.GetComponent<SpriteRenderer>().color;
        Box08.DisableKeyword("_EMISSION");
        Color09 = Energy08.GetComponent<SpriteRenderer>().color;
        Box09.DisableKeyword("_EMISSION");

        Energy01.GetComponent<SpriteRenderer>().color = Color.black;
        Energy02.GetComponent<SpriteRenderer>().color = Color.black;
        Energy03.GetComponent<SpriteRenderer>().color = Color.black;
        Energy04.GetComponent<SpriteRenderer>().color = Color.black;
        Energy05.GetComponent<SpriteRenderer>().color = Color.black;
        Energy06.GetComponent<SpriteRenderer>().color = Color.black;
        Energy07.GetComponent<SpriteRenderer>().color = Color.black;
        Energy08.GetComponent<SpriteRenderer>().color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if(ES3.KeyExists("Passed Scene01") && ES3.Load<bool>("Passed Scene01") == true)
        {
            C2.SetActive(false);
            B2.SetActive(true);
            Energy01.GetComponent<SpriteRenderer>().color = Color02;
            Box02.EnableKeyword("_EMISSION");

        }
        if (ES3.KeyExists("Passed Scene02") && ES3.Load<bool>("Passed Scene02") == true)
        {
            C3.SetActive(false);
            B3.SetActive(true);
            Energy02.GetComponent<SpriteRenderer>().color = Color03;
            Box03.EnableKeyword("_EMISSION");
        }
        if (ES3.KeyExists("Passed Scene03") && ES3.Load<bool>("Passed Scene03") == true)
        {
            C4.SetActive(false);
            B4.SetActive(true);
            Energy03.GetComponent<SpriteRenderer>().color = Color04;
            Box04.EnableKeyword("_EMISSION");
        }
        if (ES3.KeyExists("Passed Scene04") && ES3.Load<bool>("Passed Scene04") == true)
        {
            C5.SetActive(false);
            B5.SetActive(true);
            Energy04.GetComponent<SpriteRenderer>().color = Color05;
            Box05.EnableKeyword("_EMISSION");
        }
        if (ES3.KeyExists("Passed Scene05") && ES3.Load<bool>("Passed Scene05") == true)
        {
            C6.SetActive(false);
            B6.SetActive(true);
            Energy05.GetComponent<SpriteRenderer>().color = Color06;
            Box06.EnableKeyword("_EMISSION");
        }
        if (ES3.KeyExists("Passed Scene06") && ES3.Load<bool>("Passed Scene06") == true)
        {
            C7.SetActive(false);
            B7.SetActive(true);
            Energy06.GetComponent<SpriteRenderer>().color = Color07;
            Box07.EnableKeyword("_EMISSION");
        }
        if (ES3.KeyExists("Passed Scene07") && ES3.Load<bool>("Passed Scene07") == true)
        {
            C8.SetActive(false);
            B8.SetActive(true);
            Energy07.GetComponent<SpriteRenderer>().color = Color08;
            Box08.EnableKeyword("_EMISSION");
        }
        if (ES3.KeyExists("Passed Scene08") && ES3.Load<bool>("Passed Scene08") == true)
        {
            C9.SetActive(false);
            B9.SetActive(true);
            Energy08.GetComponent<SpriteRenderer>().color = Color09;
            Box09.EnableKeyword("_EMISSION");
        }


        if (ES3.KeyExists("Passed FinalBossScene") && ES3.Load<bool>("Passed FinalBossScene") == true)
        {
            ButtonSpeed.SetActive(true);
            ButtonWave.SetActive(true);
            Candado1.SetActive(false);
            Candado2.SetActive(false);
        }
        else
        {
            ButtonSpeed.SetActive(false);
            ButtonWave.SetActive(false);
            Candado1.SetActive(true);
            Candado2.SetActive(true);
        }
    }
}
