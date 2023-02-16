using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWareAnimation : MonoBehaviour
{
    public Animator anim;
     public  EnemyBehaviour enemy;
    bool isDashing;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        enemy = GetComponentInParent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Velocity", enemy.rb.velocity.x); 
        Debug.Log(enemy.isDashing + "ENEMYDASH");
        //anim.Play("Walk");
    }
}
