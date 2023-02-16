using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    Movement mv;
    public float directionX;
    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = mv.directionX;
    }
}
