using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimScale : MonoBehaviour
{

    public RLProGlitch2 GlitchWin;
    public GameObject PostProcessing;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PostProcessVolume volume = PostProcessing.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out GlitchWin);
        GlitchWin.enabled.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
