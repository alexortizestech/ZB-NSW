using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobitoMovement : MonoBehaviour
{
    
    float StartY, StartX;
    float speed = 0.2f;
    float delta = 0.3f;
    public float y, x;
    float timer;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        rb2d.transform.Rotate(0, 0, oscillate(timer, 2, 1));

        y = StartY + Mathf.PingPong(speed * Time.time, delta);
        x = StartX + Mathf.PingPong(speed * Time.time, delta);
        Vector3 pos = new Vector3(x, y, 0);
      // transform.position = pos;
        Debug.Log("GLOBITO " + pos.y);
        float oscillate(float time, float speed, float scale)
        {
            return Mathf.Cos(time * speed / Mathf.PI) * scale;
        }

    }
}
