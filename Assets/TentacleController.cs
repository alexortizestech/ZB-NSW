using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : MonoBehaviour
{
    public float count, limit;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        count += 1 * Time.deltaTime;
        if (count >= limit)
        {
            anim.enabled = true;
        }
    }
}
