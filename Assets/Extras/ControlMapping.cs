using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMapping : MonoBehaviour
{
    public Sprite PS4ReloadUp, PS4ReloadDown, RTUp, RTDown, KeyboardUP, KeyboardDown;
    public GameObject gm;
    public GameObject Up, Down;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

         if (gm.GetComponent<JoystickDetector>().Xbox_One_Controller == 1)
        {
            Up.GetComponent<SpriteRenderer>().sprite = RTUp;
            Down.GetComponent<SpriteRenderer>().sprite = RTDown;
        }
        else if (gm.GetComponent<JoystickDetector>().PS4_Controller == 1)
        {
            Up.GetComponent<SpriteRenderer>().sprite = PS4ReloadUp;
            Down.GetComponent<SpriteRenderer>().sprite = PS4ReloadDown;
        }
        else if (gm.GetComponent<JoystickDetector>().Keyboard_Controller == 1)
        {
            Up.GetComponent<SpriteRenderer>().sprite = KeyboardUP;
            Down.GetComponent<SpriteRenderer>().sprite = KeyboardDown;
        }

    }
}
