using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoss : MonoBehaviour
{
    public GameObject bullet, ShootSpawn;
    float numBullets;
    // Start is called before the first frame update
    void Start()
    {
        
        numBullets = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShootAttack()
    {
        
        
            Instantiate(bullet, ShootSpawn.transform.position, Quaternion.identity);
            bullet.transform.localPosition = new Vector3(bullet.transform.position.x, bullet.transform.position.x, 0);
           
        

    }
}
