using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetMainAudio : MonoBehaviour
{
    public Slider sl;
    // Start is called before the first frame update
    public AudioMixer mixer;
    public string parameterName;

    protected float Parameter
    {
        get
        {
            float parameter;
            mixer.GetFloat(parameterName, out parameter);
            return parameter;
        }
        set
        {
            mixer.SetFloat(parameterName, value);
        }
    }

    private void Awake()
    {
        changeMusicVolume();
    }

    public void updateMusicVolume()
    {
        mixer.SetFloat(parameterName, sl.value);
        if(parameterName == "MasterVolume")
        {
            PlayerPrefs.SetFloat("MusicVolume", sl.value);
        }
        else
        {
            PlayerPrefs.SetFloat("SfxVolume", sl.value);
        }
    }

    public void changeMusicVolume()
    {
        if (parameterName == "MasterVolume")
        {
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                sl.value = PlayerPrefs.GetFloat("MusicVolume");
                mixer.SetFloat(parameterName, PlayerPrefs.GetFloat("MusicVolume"));
            }
            else
            {
                sl.value = 0;
                mixer.SetFloat(parameterName, 0);
            }
            
        }
        else
        {
            if (PlayerPrefs.HasKey("SfxVolume"))
            {
                sl.value = PlayerPrefs.GetFloat("SfxVolume");
                mixer.SetFloat(parameterName, PlayerPrefs.GetFloat("SfxVolume"));
            }
            else
            {
                sl.value = 0;
                mixer.SetFloat(parameterName, 0);
            }
            
        }
    }
}
