using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public Transform eye;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(Player.position, -Vector2.up);
    
        // If it hits something...
        Debug.DrawLine(transform.position, (Player.position - Vector3.up), Color.red);

        if(Player.position.x>20 && Player.position.x< 40 && Player.position.y <=-10)
        {
            eye.rotation = Quaternion.Euler(new Vector3(65, eye.rotation.y, eye.rotation.z));
            eye.LookAt(Player);
        }
    }
}
