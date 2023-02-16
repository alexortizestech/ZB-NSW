using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour
{
    Scene scene;

    public GameObject first;

public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        volumeSlider.value = 1;
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }


      //  SetSelected(first);

    }
    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void PlaySpeedRun()
    {
        
    }
    public void Reboot()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }
    public void SetSelected(GameObject selectableObject)
    {
        // Set the currently selected GameObject
        EventSystem.current.SetSelectedGameObject(selectableObject);
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
            Save();
    }
  void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    public void Scene07()
    {
        SceneManager.LoadScene("Scene07");
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void PlayWave()
    {
        SceneManager.LoadScene("WaveScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

   


