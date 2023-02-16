using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIntensity : MonoBehaviour
{
    public Material mat;
    Movement move;
    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!move.controlPackage)
        {
            mat.SetColor("Color_160F9D85", new Color(191 * 0.0f, 7 * 0.0f, 13 * 0.0f));
        }else if (move.controlPackage)
        {
            mat.SetColor("Color_160F9D85", new Color(191 * 0.2f, 7 * 0.2f, 13 * 0.2f));
        }
    }
}
