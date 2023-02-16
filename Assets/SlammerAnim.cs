using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerAnim : MonoBehaviour
{
    public Animator anim;
    public EnemyBehaviour enemy;
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
    }
}
