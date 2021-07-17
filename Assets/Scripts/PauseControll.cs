using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.SceneManagement;

public class PauseControll : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool isPaused = false;
    GameObject pauseScreen;
    Controller controller;
    void Start()
    {
        // Get the pause screen object
        pauseScreen = GameObject.Find("MainSceneUI").transform.Find("PauseScreen").gameObject;
        controller = gameObject.GetComponent<Controller>();
        pauseScreen.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // toggle the pause state
    public void TogglePaus()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseScreen.active = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseScreen.active = true;
        }
    }
    // Back to main Menu
    public void MainMenuButton()
    {
        TogglePaus();
        Destroy(GameObject.Find("DataManager"));
        if(controller.data.activeGameMode == DataManager.GameMode.Online)
        {
            if(NetworkManager.Singleton.IsHost)
            {
                NetworkSceneManager.SwitchScene("MainMenu");
                NetworkManager.Singleton.StopHost();
            }
            else
            {
                NetworkManager.Singleton.StopClient();
            }
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            //UnityEngine.SceneManagement.SceneManager.UnloadScene("MainScene");
        }
        return;
    }
}
