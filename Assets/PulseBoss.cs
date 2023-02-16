using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBoss : MonoBehaviour
{
    public GameObject PulseClone, PulsePrefab;
    public float PulseSpeed, pulseCount, pulseLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pulseCount += 1 * Time.deltaTime;
        if (PulseClone)
        {
            PulseClone.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * PulseSpeed;
            PulseClone.transform.localPosition = new Vector3(PulseClone.transform.position.x, PulseClone.transform.position.y, 0);
            PulseClone.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (pulseCount >= pulseLimit)
        {
            Destroy(PulseClone);
        }
    }

    public void PulseAttack()
    {
        PulseClone = Instantiate(PulsePrefab, transform.position, transform.rotation);
        pulseCount = 0;
    }
}
