using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class SplashScreenScript : MonoBehaviour
{
    public GameObject gif, canvas2;
    public GameObject i1, i2, i3, i4, i5, i6, i7, team, logo;
    public RLProGlitch2 GlitchWin;
    public GameObject postprocessing;
    public AudioSource audiog;
    bool isDone;
    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume volume = postprocessing.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out GlitchWin);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 5f && !isDone)
        {
            gif.SetActive(false);
            canvas2.SetActive(true);
            StartCoroutine(SplashScreen(0.5f));
            isDone = true;
        }
    }


    IEnumerator SplashScreen(float time)
    {
       
        yield return new WaitForSeconds(time);
        i1.SetActive(false);
        i2.SetActive(true);

        yield return new WaitForSeconds(time);
        i2.SetActive(false);
        i3.SetActive(true);

        yield return new WaitForSeconds(time);
        i3.SetActive(false);
        i4.SetActive(true);

        yield return new WaitForSeconds(time);
        i4.SetActive(false);
        i5.SetActive(true);

        yield return new WaitForSeconds(time);
        i5.SetActive(false);
        i6.SetActive(true);

        yield return new WaitForSeconds(time);
        i6.SetActive(false);
        i7.SetActive(true);

        GlitchWin.enabled.value = true;
        audiog.Play();

        yield return new WaitForSeconds(2f);
        GlitchWin.enabled.value = false;
        audiog.Stop();
        i7.SetActive(false);
        team.SetActive(true);
        yield return new WaitForSeconds(2f);

        team.SetActive(false);

        logo.SetActive(true);
        yield return new WaitForSeconds(2f);

        SceneManager.LoadSceneAsync("MainMenuScene");

    }
}
