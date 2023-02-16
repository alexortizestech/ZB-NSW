using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public FinalBoss boss;
    public GameObject LeftArm, RightArm, CenterArm;
    public Material matleft, matright, matcenter;
    Color baseColor;
    public GameObject EyeCollider;
    public Material eye;
    // Start is called before the first frame update
    void Start()
    {
        baseColor = new Color(0, 91, 2)*0.016f;
        eye.SetColor("Color_7523A9E5", new Color(26, 191, 0) * 0.015f);
    }

    // Update is called once per frame
    void Update()
    {
        if (RightArm.GetComponent<AnimationBoss>().canHurt)
        {
            matright.SetColor("_EmissionColor", new Color(255, 0, 138) * 0.009f);
        }
        else
        {
            matright.SetColor("_EmissionColor", baseColor);
        }

        if (LeftArm.GetComponent<AnimationBoss>().canHurt)
        {
            matleft.SetColor("_EmissionColor", new Color(255, 0, 138) * 0.009f) ;
        }
        else
        {
            matleft.SetColor("_EmissionColor", baseColor);
        }

        if (CenterArm.GetComponent<AnimationBoss>().canHurt)
        {
            matcenter.SetColor("_EmissionColor", new Color(255, 0, 138) * 0.009f);
        }
        else
        {
            matcenter.SetColor("_EmissionColor", baseColor);
        }

        if (boss.Health == 1)
        {
            EyeCollider.SetActive(true);
            eye.SetColor("Color_7523A9E5", new Color(255, 0, 138) * 0.018f);
        }
    }
}
