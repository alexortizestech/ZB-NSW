using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class FinalTextScript : MonoBehaviour
{
    public GameObject Text1, Text2;
    public RLProGlitch2 GlitchWin;
    public GameObject PostProcessing;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PostProcessVolume volume = PostProcessing.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out GlitchWin);
        GlitchWin.enabled.value = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 2)
        {
            GlitchWin.enabled.value = false;
        }
        StartCoroutine(FinalText());
    }

    IEnumerator FinalText()
    {
        yield return new WaitForSeconds(2f);
        Text1.SetActive(false);
        Text2.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CreditsScene");
    }
}
