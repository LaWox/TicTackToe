using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UI_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject NetworkMenu;
    DataManager data;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        NetworkMenu.SetActive(false);
        data = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    public void LocalButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        data.activeGameMode = DataManager.GameMode.Local;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        MainMenu.SetActive(false);
    }

    public void AIButton()
    {
        // update GameMode
        data.activeGameMode = DataManager.GameMode.AI;
        // Load next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        MainMenu.SetActive(false);
    }

    public void OnlineButton()
    {
        // Show Main Menu
        data.activeGameMode = DataManager.GameMode.Online;
        MainMenu.SetActive(false);
        NetworkMenu.SetActive(true);  
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}