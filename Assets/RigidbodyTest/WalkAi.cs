using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityAnimator
{


    public class WalkAi : Action
    {
        public GameObject enemy;
        public Vector2 Direction;
        public Rigidbody2D rb;
        public float limitL, limitR, Walk, scuttleSpeed;
        // Start is called before the first frame update
        void Start()
        {
            rb.velocity += Direction * Time.deltaTime;
            limitL = enemy.transform.position.x - Walk;
            limitR = enemy.transform.position.x + Walk;
            rb = GetComponent<Rigidbody2D>();
            Direction = Vector2.right;
        }   

    // Update is called once per frame
        void Update()
        {

            rb.velocity += Direction * Time.deltaTime;


            rb.AddForce(Direction * scuttleSpeed * Time.deltaTime);
        }


        IEnumerator WaitRoutineLeft(float time)
        {
            yield return new WaitForSeconds(time);
            Direction = Vector3.left;
            //fov.direction = Vector2.left;

        }
        IEnumerator WaitRoutineRight(float time)
        {
            yield return new WaitForSeconds(time);
            Direction = Vector3.right;
            //fov.direction = Vector2.right;

        }
    }
}