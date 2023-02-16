using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsywareAnimation : MonoBehaviour
{
    public Animator anim;
    public EnemyBehaviour enemy;
    bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponentInParent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
