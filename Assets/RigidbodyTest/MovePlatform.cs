using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    public bool MovingY;
    public bool MovingX;
    float StartY,StartX;
    float speed = 0.2f;
    float delta = 0.3f;
    public float y,x;//delta is the difference between min y to max y.
    private void Start()
    {
        StartY = transform.position.y;
        StartX = transform.position.x;
    }
    void Update()
    {
        if (MovingY)
        {
            y = StartY + Mathf.PingPong(speed * Time.time, delta);
            Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
            transform.position = pos;
        }

        if (MovingX)
        {
            x = StartX + Mathf.PingPong(speed * Time.time, delta);
            Vector3 pos = new Vector3(x, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}