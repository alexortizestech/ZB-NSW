using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpColor : MonoBehaviour
{
    Movement move;
    public Material mat;
    public Material mat2;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (move.CountSlash == 0)
        {
            mat.SetColor("Color_4C7EF6D6", new Color(0,0,0));

            mat2.SetColor("Color_4C7EF6D6", new Color(0, 0, 0));
        }
        if (move.Combo == false && move.CountSlash == 1)
        {

            mat.SetColor("Color_4C7EF6D6", new Color(185 * 0.05f, 191 * 0.05f, 91 * 0.05f));

            mat2.SetColor("Color_4C7EF6D6", new Color(185 * 0.05f, 191 * 0.05f, 91 * 0.02f));
        }

        if (move.Damage == 1 && move.Combo == true)
        {

            mat.SetColor("Color_4C7EF6D6", new Color(255, 76, 0) * 0.05f);
            mat2.SetColor("Color_4C7EF6D6", new Color(255, 76, 0) * 0.02f);
        }


        if (move.Damage == 2 && move.Combo == true)
        {

            mat.SetColor("Color_4C7EF6D6", new Color(255, 5, 0) * 0.05f);
            mat2.SetColor("Color_4C7EF6D6", new Color(255, 5, 0) * 0.02f);

        }

        if (move.Damage >= 3 && move.Combo == true)
        {
            mat.SetColor("Color_4C7EF6D6", new Color(191, 0, 34) * 0.05f);
            mat2.SetColor("Color_4C7EF6D6", new Color(191, 0, 34) * 0.02f);

        }

    
    }
}
