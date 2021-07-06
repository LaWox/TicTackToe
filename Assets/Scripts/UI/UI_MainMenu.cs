using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    LevelData levelData;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        levelData = Resources.Load<LevelData>("Data/LevelData");
        //Debug.Log(levelData.activeMode);
    }

    public void LocalButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        levelData.activeMode = LevelData.GameMode.Local;
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlatonScene");
        MainMenu.SetActive(false);
    }

    public void AIButton()
    {
        // update GameMode
        levelData.activeMode = LevelData.GameMode.AI;
        // Load next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlatonScene");
        MainMenu.SetActive(false);
    }

    public void OnlineButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}