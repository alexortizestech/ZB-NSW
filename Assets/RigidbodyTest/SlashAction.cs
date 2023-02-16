using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityAnimator
{
public class SlashAction : Action
{
    // Start is called before the first frame update
    Rigidbody2D body;
    Animator animator;
    EnemyBehaviour enemy;
   protected  DirectionManager dm;
    // protected GameObject player;
      
        // Update is called once per frame
        public override void OnAwake()
    {
          //  dm = player.GetComponent<DirectionManager>();
            
        body = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
           
    }
}
}
