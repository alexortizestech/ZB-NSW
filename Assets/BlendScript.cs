using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendScript : MonoBehaviour
{
    float current;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        current = this.gameObject.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
        this.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, current + 4.5f * Time.deltaTime);
        Debug.Log("CURRENT BLEND" + current);
    }
}
