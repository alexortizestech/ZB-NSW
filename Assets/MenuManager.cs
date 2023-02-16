using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
public class MenuManager : MonoBehaviour
{
    DepthOfField dph;
    public Player player;
    public GameObject Main, Wave, Speed;
    public GameObject MainBt, WaveBt, SpeedBt;
    public GameObject PostProcessing;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
        PostProcessVolume volume = PostProcessing.GetComponent<PostProcessVolume>();
       
        volume.profile.TryGetSettings(out dph);

    }

    // Update is called once per frame
    void Update()
    {


        if (ES3.KeyExists("Passed FinalBossScene") && ES3.Load<bool>("Passed FinalBossScene") == true)
        {

        
            if (Main.activeInHierarchy)
            {
                dph.focalLength.value = 16.2f;
                if (player.GetButtonDown("RT"))
                {
                    Main.SetActive(false);
                    Speed.SetActive(true);
                EventSystem.current.SetSelectedGameObject(SpeedBt);
                }

                if (player.GetButtonDown("LT"))
                {
                    Main.SetActive(false);
                    Wave.SetActive(true);
                EventSystem.current.SetSelectedGameObject(WaveBt);

                }
            }



            if (Wave.activeInHierarchy)
            {
                 dph.focalLength.value = 300;

                if (player.GetButtonDown("RT"))
                {
                    Wave.SetActive(false);
                    Main.SetActive(true);

                EventSystem.current.SetSelectedGameObject(MainBt);
                }

        }
       

            if (Speed.activeInHierarchy)
            {
                dph.focalLength.value = 300;

                if (player.GetButtonDown("LT"))
                {
                    Speed.SetActive(false);
                    Main.SetActive(true);

                EventSystem.current.SetSelectedGameObject(MainBt);
            }

            }
           
         
         
         



        }

    }
}
