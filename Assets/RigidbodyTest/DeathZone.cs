using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("DeathZone");
            collision.gameObject.GetComponent<Movement>().Die();
            collision.gameObject.GetComponent<Movement>().StopAllCoroutines();
            collision.gameObject.GetComponent<Movement>().Health--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
