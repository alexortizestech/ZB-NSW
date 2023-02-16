using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat;
    Movement move;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponentInParent<Movement>();
        if (mat.name == "PiMaterial")
        {
            mat.SetColor("Color_AA231C3C", new Color(255, 255, 255) * 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (move.CountSlash == 0)
        {
            mat.SetColor("Color_7523A9E5", new Color(0,0,0));
            if (mat.name == "PiMaterial")
            {
                mat.SetColor("Color_AA231C3C", new Color(255, 255, 255) * 0f);
            }
        }
        if (move.Combo == false && move.CountSlash==1)
        {
            
            mat.SetColor("Color_7523A9E5", new Color(185*0.05f, 191 * 0.05f, 91 * 0.05f));
            if (mat.name == "PiMaterial")
            {
                mat.SetColor("Color_AA231C3C", new Color(255, 255, 255) * 0f);
            }

        }

        if (move.Damage == 1 && move.Combo == true)
        {
            
            mat.SetColor("Color_7523A9E5", new Color(255, 76, 0)*0.2f);
            if (mat.name == "PiMaterial")
            {
                mat.SetColor("Color_AA231C3C", new Color(255, 255, 255) * 0f);
            }
        }


        if (move.Damage == 2 && move.Combo == true)
        {
            
            mat.SetColor("Color_7523A9E5", new Color(255, 5, 0)*0.3f);
            if (mat.name == "PiMaterial")
            {
                mat.SetColor("Color_AA231C3C", new Color(157, 0, 0) * 0.3f);
            }
            
        }

        if (move.Damage >= 3 && move.Combo == true)
        {
           
            mat.SetColor("Color_7523A9E5", new Color(191, 0, 34)*0.3f);
            if (mat.name == "PiMaterial")
            {
                mat.SetColor("Color_AA231C3C", new Color(67, 0, 191) * 0.3f);
            }
        }
    }
}
