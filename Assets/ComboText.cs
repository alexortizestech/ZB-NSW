using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboText : MonoBehaviour
{
    public GameObject Player;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        text.text = ("x" +Player.GetComponent<Movement>().Damage);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime, 0);
    }
}
