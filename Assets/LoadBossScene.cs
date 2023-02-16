using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadBossScene : MonoBehaviour
{
    public float count;
    public float limit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += 1 * Time.deltaTime;
        if (count >= limit)
        {
            SceneManager.LoadScene("FinalBossScene");
        }
    }
}
