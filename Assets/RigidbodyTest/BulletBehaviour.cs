using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	float moveSpeed = 7f;

	Rigidbody2D rb;

	Movement target;
	Vector2 moveDirection;
	public GameObject Explosion;
	public GameObject clone;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Movement>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		//Destroy(gameObject, 3f);
	}




	private void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("Bullet Coll" + other.gameObject.tag);
		Debug.Log("Bullet Name" + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
			var Player = GameObject.Find("Player");
			
			if (Player.GetComponent<Movement>().isDashing == false)
			{
				Player.GetComponent<Movement>().Die();

			}
		
			if (other.GetComponent<Movement>().isDashing == false)
				other.GetComponent<Movement>().Health -= 1;

		}
        if (other.gameObject.CompareTag("Player"))
        {

			var Player = GameObject.Find("Player");
			if (other.GetComponent<Movement>().isDashing == false)
            {
				Player.GetComponent<Movement>().Health--;
				if (other.GetComponent<Movement>().isDashing == false)
					other.GetComponent<Movement>().Health -= 1;
			}
				
        }
		if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("ShotDown") && !other.gameObject.CompareTag("Boss"))
        { Destroy(this.gameObject);
			clone = Instantiate(Explosion, transform.position, transform.rotation);
			Destroy(clone, 2f);
		}
		
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != ("Boss") )
        {
			Debug.Log("NAME " + collision.gameObject.name);
			clone = Instantiate(Explosion, transform.position, transform.rotation);
			Destroy(clone, 2f);
			Destroy(this.gameObject);
		}
	
    }
}
