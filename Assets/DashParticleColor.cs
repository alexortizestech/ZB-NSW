using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticleColor : MonoBehaviour
{
   public Movement move;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
       
        move = GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move.Combo == false && move.CountSlash == 1)
        {

            mat.SetColor("_BaseColor", new Color(203 * 0.01f, 199 * 0.01f, 101 * 0.01f));
           
         

        }

        if (move.Damage == 1 && move.Combo == true)
        {

            mat.SetColor("_BaseColor", new Color(255, 76, 0) * 0.05f);
         
        }


        if (move.Damage == 2 && move.Combo == true)
        {

            mat.SetColor("_BaseColor", new Color(255, 5, 0) * 0.05f);
          

        }

        if (move.Damage >= 3 && move.Combo == true)
        {

            mat.SetColor("_BaseColor", new Color(255, 0, 174) * 0.05f);
            mat.SetColor("_Color", new Color(191, 0, 34));

        }
    }
}
