using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWareAnimation : MonoBehaviour
{
    public Animator anim;
    public EnemyBehaviour enemy;
    bool isShooting;
    public bool onGround;
    public Material BowMaterial;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        enemy = GetComponentInParent<EnemyBehaviour>();
        anim.SetBool("onGround", onGround);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ColorChange()
    {
        //BowMaterial.SetColor("Color_AA231C3C", new Color(18 * 0.51f, 191 * 0.51f, 105 * 0.51f));
    }
   
}
