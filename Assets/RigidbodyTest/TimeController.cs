using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    
    public float count;
    public float limit;
    public NailedRigidbody nr;
    // public KeyCode Slower;
    public float Slowing;
    public float pressed;
    public Movement mv;
    public float CoolDown;
   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown -= Time.deltaTime;
        if (CoolDown <= 0) {
            CoolDown = 0;
        }


        count += 1 * Time.deltaTime;

        if(mv!=null)
        if (mv.player.GetButtonUp("BulletTime")&&CoolDown==0)
        {
            
            mv.Negative.enabled.value = true;
            pressed++;
            
            if (pressed%2!=0 && mv.canBulletTime)
            {
                count = 0;
                // count += 1 * Time.deltaTime;
                Time.timeScale = 0.25f;
                nr.direction *= 4;
                CoolDown = 5;
            }

            if (pressed % 2 == 0 && mv.canBulletTime)
            {
                ReturnTime();
            }

        }

        if (count >= limit)
        {
            ReturnTime();
        }

        if (mv.player.GetButtonDown("Cancel") && Time.timeScale!=1)
        {
            ReturnTime();
        }
        Debug.Log(Time.timeScale);
    }


   
    void ReturnTime()
    {
        if(mv!=null)
        mv.Negative.enabled.value = false;
        //pressed = false;
        Time.timeScale = 1;
        //count = 0;
    }
}
