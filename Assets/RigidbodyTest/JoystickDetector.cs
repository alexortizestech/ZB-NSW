using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDetector : MonoBehaviour
{
    public int Xbox_One_Controller = 0;
    public int PS4_Controller = 0;
    public int Keyboard_Controller = 0;


    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19)
            {
                print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
                Keyboard_Controller = 0;
            }
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;
                Keyboard_Controller = 0;
            }

            if (names[x].Length == 0)
            {
                print("PLAYING WITH KEYBOARD");
                PS4_Controller = 0;
                Xbox_One_Controller = 0;
                Keyboard_Controller = 1;
            }
            else
            {
                Keyboard_Controller = 1;

            }
        }
        if (Xbox_One_Controller == 1)
        {
            //do something
        }
        else if (PS4_Controller == 1)
        {
            //do something
        }else if (Keyboard_Controller == 1)
        {
            //do something
        }
        else
        {
            // there is no controllers
        }
    }
}

