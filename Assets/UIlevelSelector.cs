using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
using UnityEngine.EventSystems;

public class UIlevelSelector : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("UICancel"))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
    public void PlayWave()
    {
        SceneManager.LoadScene("WaveScene");
    }
    public void SetSelected(GameObject selectableObject)
    {
        // Set the currently selected GameObject
        EventSystem.current.SetSelectedGameObject(selectableObject);
    }

    public void Play()
    {
        SceneManager.LoadScene("LabScene");
    }
    public void Level01()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void Level02()
    {
        SceneManager.LoadScene("Scene02");
    }
    public void Level03()
    {
        SceneManager.LoadScene("Scene03");
    }
    public void Level04()
    {
        SceneManager.LoadScene("Scene04");
    }
    public void Level05()
    {
        SceneManager.LoadScene("Scene05");
    }
    public void Level06()
    {
        SceneManager.LoadScene("Scene06");
    }
    public void Level07()
    {
        SceneManager.LoadScene("Scene07");
    }
    public void Level08()
    {
        SceneManager.LoadScene("Scene08");
    }
    public void Level09()
    {
        SceneManager.LoadScene("FinalBossScene");
    }
}
