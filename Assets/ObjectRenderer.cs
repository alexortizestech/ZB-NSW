using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRenderer : MonoBehaviour
{
    public GameObject[] AllGo;
    // Start is called before the first frame update
    void Start()
    {
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        AllGo = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
        int Wall = LayerMask.NameToLayer("Wall");
        int Ground = LayerMask.NameToLayer("Ground");
        int Enemy = LayerMask.NameToLayer("Enemy");
        foreach (GameObject Gobject in AllGo)
        {
            if(Gobject.layer == Enemy || Gobject.layer == Ground || Gobject.layer == Wall)
            {
                if (Gobject.GetComponent<Renderer>() != null)
                {
                    if (Gobject.GetComponent<Renderer>().isVisible)
                    {

                        Gobject.GetComponent<Renderer>().enabled = true;
                    }
                    else
                    {
                        Gobject.GetComponent<Renderer>().enabled = false;
                    }
                }

                
            }
        }
    }
   

}
