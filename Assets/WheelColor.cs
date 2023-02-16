using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelColor : MonoBehaviour
{
    public Image Fill;
    public Movement mv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            if (mv.Damage == 1 && mv.Combo == true)
            {
                Fill.color = Color.yellow;
            } else if (mv.Damage == 2)
            {
                Fill.color = Color.red;
            } else if (mv.Damage >= 3)
            {
                Fill.color = Color.magenta;
            }
            else
            {
                Fill.color = Color.white;
            }
        }
    }
}
