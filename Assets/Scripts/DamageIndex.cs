using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DamageIndex : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public Movement mv;
    // Start is called before the first frame update
    void Start()
    {
        mv = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mv.Damage == 1)
        {
            text.color = Color.yellow;
            text.gameObject.transform.localScale= new Vector3(0.5f,0.5f,0.5f);
            
        }
        if (mv.Damage == 2)
        {
            text.color = Color.red;
            text.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }

        if (mv.Damage == 3)
        {
            text.color = Color.magenta;
            text.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            
        }
        if (mv.Combo == false)
        {
            text.enabled = false;
        }
        if (mv.Combo == true)
        {
            text.enabled = true;
            text.text = "damage x" + mv.Damage;
        }
      
    }
}
