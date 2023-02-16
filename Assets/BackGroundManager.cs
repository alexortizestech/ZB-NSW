using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public float multiplier;
    public Material mat;
    public GameObject PlayButton, ControlButton, OptionsButton, ExitButton;
    public GameObject PLayBG, ControlBG, OptionsBG, ExitBG;
    public GameObject PlayBorder, ControlBorder, OptionsBorder, ExitBorder;
    public GameObject PlayBlur, ControlBlur, OptionsBlur, ExitBlur;
    public GameObject HairParticle, Gear1, Gear2;
    public Material globitocuerpo, globitocabeza, piespada,picuerpo,gears;

    public float GearIntensity;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = new Color(0, 191, 166);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (EventSystem.current.currentSelectedGameObject == PlayButton)
        {
            PLayBG.SetActive(true);
            ControlBG.SetActive(false);
            OptionsBG.SetActive(false);
            ExitBG.SetActive(false);


            PlayBorder.SetActive(false);
            ControlBorder.SetActive(true);
            OptionsBorder.SetActive(true);
            ExitBorder.SetActive(true);

            PlayBlur.SetActive(true);
            ControlBlur.SetActive(false);
            OptionsBlur.SetActive(false);
            ExitBlur.SetActive(false);
            mat.SetColor("Color_160F9D85", new Color(255, 0, 42)* multiplier);


            HairParticle.SetActive(true);
            Gear1.GetComponent<OptionsAnimation>().enabled = false;
            Gear2.GetComponent<OptionsAnimation>().enabled = false;

            globitocabeza.SetFloat("Vector1_4EFFB852", 50);
            globitocuerpo.SetFloat("Vector1_4EFFB852", 50);
            picuerpo.SetColor("Color_7523A9E5", new Color(185 * 0.05f, 191 * 0.05f, 91 * 0.05f));
            piespada.SetColor("Color_7523A9E5", new Color(185 * 0.05f, 191 * 0.05f, 91 * 0.05f));
            gears.DisableKeyword("_EMISSION");

        }
        else if (EventSystem.current.currentSelectedGameObject ==OptionsButton)
        {
            PLayBG.SetActive(false);
            ControlBG.SetActive(false);
            OptionsBG.SetActive(true);
            ExitBG.SetActive(false);

            PlayBorder.SetActive(true);
            ControlBorder.SetActive(true);
            OptionsBorder.SetActive(false);
            ExitBorder.SetActive(true);

            PlayBlur.SetActive(false);
            ControlBlur.SetActive(false);
            OptionsBlur.SetActive(true);
            ExitBlur.SetActive(false);
            mat.SetColor("Color_160F9D85", new Color(191, 178, 12)* multiplier/2);

            HairParticle.SetActive(false);
            Gear1.GetComponent<OptionsAnimation>().enabled = true;
            Gear2.GetComponent<OptionsAnimation>().enabled = true;



            globitocabeza.SetFloat("Vector1_4EFFB852", 50);
            globitocuerpo.SetFloat("Vector1_4EFFB852", 50);
            picuerpo.SetColor("Color_7523A9E5", new Color(0 * 0.05f, 0 * 0, 91 * 0));
            piespada.SetColor("Color_7523A9E5", new Color(0 * 0, 191 * 0, 91 * 0));


            gears.EnableKeyword("_EMISSION");
        }
        else if (EventSystem.current.currentSelectedGameObject ==ControlButton)
        {
            PLayBG.SetActive(false);
            ControlBG.SetActive(true);
            OptionsBG.SetActive(false);
            ExitBG.SetActive(false);

            PlayBorder.SetActive(true);
            ControlBorder.SetActive(false);
            OptionsBorder.SetActive(true);
            ExitBorder.SetActive(true);

            PlayBlur.SetActive(false);
            ControlBlur.SetActive(true);
            OptionsBlur.SetActive(false);
            ExitBlur.SetActive(false);
            mat.SetColor("Color_160F9D85", new Color(19, 243, 166)* multiplier/2);

            HairParticle.SetActive(false);
            Gear1.GetComponent<OptionsAnimation>().enabled = false;
            Gear2.GetComponent<OptionsAnimation>().enabled = false;


            

            globitocabeza.SetFloat("Vector1_4EFFB852", 0.2f);
            globitocuerpo.SetFloat("Vector1_4EFFB852", 0.2f);
            picuerpo.SetColor("Color_7523A9E5", new Color(0 * 0.05f, 0 * 0, 91 * 0));
            piespada.SetColor("Color_7523A9E5", new Color(0 * 0, 191 * 0, 91 * 0));
            gears.DisableKeyword("_EMISSION");

        }
        else if((EventSystem.current.currentSelectedGameObject == ExitButton))
        {
            PLayBG.SetActive(false);
            ControlBG.SetActive(false);
            OptionsBG.SetActive(false);
            ExitBG.SetActive(true);


            PlayBorder.SetActive(true);
            ControlBorder.SetActive(true);
            OptionsBorder.SetActive(true);
            ExitBorder.SetActive(false);

            PlayBlur.SetActive(false);
            ControlBlur.SetActive(false);
            OptionsBlur.SetActive(false);
            ExitBlur.SetActive(true);
            mat.SetColor("Color_160F9D85", new Color(255, 255, 255)* multiplier);

            HairParticle.SetActive(false);
            Gear1.GetComponent<OptionsAnimation>().enabled = false;
            Gear2.GetComponent<OptionsAnimation>().enabled = false;
            globitocabeza.SetFloat("Vector1_4EFFB852", 50);
            globitocuerpo.SetFloat("Vector1_4EFFB852", 50);
            picuerpo.SetColor("Color_7523A9E5", new Color(0 * 0.05f, 0 * 0, 91 * 0));
            piespada.SetColor("Color_7523A9E5", new Color(0 * 0, 191 * 0, 91 * 0));
            gears.DisableKeyword("_EMISSION");
        }
        else
        {
            PLayBG.SetActive(false);
            ControlBG.SetActive(false);
            OptionsBG.SetActive(false);
            ExitBG.SetActive(false);


            PlayBorder.SetActive(true);
            ControlBorder.SetActive(true);
            OptionsBorder.SetActive(true);
            ExitBorder.SetActive(true);

            PlayBlur.SetActive(false);
            ControlBlur.SetActive(false);
            OptionsBlur.SetActive(false);
            ExitBlur.SetActive(false);

            HairParticle.SetActive(false);
            Gear1.GetComponent<OptionsAnimation>().enabled = false;
            Gear2.GetComponent<OptionsAnimation>().enabled = false;

            globitocabeza.SetFloat("Vector1_4EFFB852", 50);
            globitocuerpo.SetFloat("Vector1_4EFFB852", 50);
            picuerpo.SetColor("Color_7523A9E5", new Color(0 * 0.05f, 0 * 0, 91 * 0));
            piespada.SetColor("Color_7523A9E5", new Color(0 * 0, 191 * 0, 91 * 0));
            gears.DisableKeyword("_EMISSION");
        }
    }

    
}
