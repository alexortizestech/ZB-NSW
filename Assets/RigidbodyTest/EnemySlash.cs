using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityAnimator
{
    public class EnemySlash : SlashAction
    {
        public Animator anim;
        public float dashSpeed;
        public GameObject Player;
         public Rigidbody2D rb;
        public float dirX;
        public bool isDashing;
        public EnemyBehaviour enemy;
        public override void OnStart()
        {
            enemy = GetComponent<EnemyBehaviour>();
            Player = GameObject.Find("Player");
            Debug.Log("Using AI");
            StartDash();

        }

        public override void OnFixedUpdate()
        {
            if (enemy.Walk > 0)
            {
                if (enemy.Direction.x > 0 && !enemy.isDashing)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                if (enemy.Direction.x < 0 && !enemy.isDashing)
                {
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                }
            }
            base.OnFixedUpdate();
        }
        public void StartDash()
        {
            
            enemy.meleeanim.anim.Play("Attack");
               isDashing = true;
            enemy.isDashing = true;
            ChangeDirection();
           // anim.Play("Attack");

            rb.velocity = Vector2.zero;
            Vector2 dir = new Vector2(dirX, 0);

            rb.AddForce ( dir.normalized * dashSpeed,ForceMode2D.Impulse);
            enemy.isDashing = true; enemy.meleeanim.anim.ResetTrigger("isDashing");
            
            StartCoroutine(Recuperation(dir));

        }


        IEnumerator Recuperation(Vector2 dir)
        {
            yield return new WaitForSeconds(1f);
            enemy.isDashing = false;
           
            yield return new WaitForSeconds(2f);
            
            
            rb.AddForce(-dir.normalized * Time.deltaTime, ForceMode2D.Impulse);
           
            yield return new WaitForSeconds(0.5f);
            rb.velocity = Vector2.zero;
            isDashing = false;
               
            
        }
     
        void ChangeDirection()
        {
            if (isDashing)
            {
                if (Player.transform.position.x > this.gameObject.transform.position.x)
                {
                    dirX = 1;
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (Player.transform.position.x < this.gameObject.transform.position.x)
                {
                    dirX = -1;
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                }
            }
           
        }
    }   
}

