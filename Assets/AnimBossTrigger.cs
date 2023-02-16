using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBossTrigger : MonoBehaviour
{

    public AnimationBoss anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.enabled = true;
            anim.anim.SetTrigger("Spawn");
            anim.anim.SetBool("Sleeping", false);
            Destroy(this.gameObject);
        }
    }
}
