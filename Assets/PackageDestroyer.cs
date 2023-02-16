using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDestroyer : MonoBehaviour
{
    public GameObject Package;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Recorded"))
        {
            StartCoroutine(Waiter());
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(Package);
    }
}
