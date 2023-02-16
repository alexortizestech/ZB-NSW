using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public Vector3 Lastpos;
    public float back;
    public NailedRigidbody nr;
    public float speed;
    Vector3 direction;
    public Vector3 lastPos;
    public LayerMask Wall;
    public LayerMask Ground;
    Rigidbody rb;
    bool Colliding;
    public Movement mv;
    // Start is called before the first frame update
    void Start()
    {
      //  rb.GetComponent<Rigidbody>();
        Wall = LayerMask.NameToLayer("Wall");
        Ground = LayerMask.NameToLayer("Ground");
        nr = GameObject.FindGameObjectWithTag("Player").GetComponent<NailedRigidbody>();
        mv = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        if (nr.direction.x != 0 || nr.direction.y != 0)
        {
            direction = new Vector3(nr.direction.x, nr.direction.y, 0);
        }
        else if (nr.direction.x == 0 && nr.direction.y == 0)
        {
            direction = new Vector3(mv.side, 0, 0);
        }

        speed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Colliding)
        {
           
           
            transform.position += direction * speed * Time.deltaTime;
            
            
          
            //Lastpos = transform.position;
        }

        if (Colliding)
        {
            
        }
        back += 1 * Time.deltaTime;
;       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Wall || other.gameObject.layer == Ground)
        {
            //transform.position = transform.position;
            Colliding = true;
           // nr.CollidingSword = true;
;            Debug.Log("collision");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Wall || collision.gameObject.layer == Ground)
        {
           // transform.position = Lastpos;
            Colliding = true;
            nr.CollidingSword = true;
            Debug.Log("collision");
           // rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.layer == Wall || collision.gameObject.layer == Ground)
        {
           // transform.position = Lastpos;
            Colliding = true;
            nr.CollidingSword = true;
            Debug.Log("collision");
            // rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void OnBecameInvisible()
    {
        back = 0;
        if (back >= 0.5f)
        {
            nr.CancelHook();
        }
       
    }

   
}
