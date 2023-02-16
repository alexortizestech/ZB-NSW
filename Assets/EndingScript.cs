using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class EndingScript : MonoBehaviour
{
    public float LimitTime;
    public RLProGlitch2 GlitchWin;
    public GameObject PostProcessing;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
      //  Camera.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        Time.timeScale = 1;
        PostProcessVolume volume = PostProcessing.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out GlitchWin);
        GlitchWin.enabled.value = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 2f)
        {
            GlitchWin.enabled.value = false;
        }
        if(Time.timeSinceLevelLoad>= LimitTime)
        {
            Application.Quit();
        }
    }
}
