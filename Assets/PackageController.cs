using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : MonoBehaviour
{
    public GameObject Package;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle_obtain"))
        {
            timer += 1 * Time.deltaTime;
        }

        if (timer >= 1f)
        {
            Destroy(Package);
        }
    }
}
