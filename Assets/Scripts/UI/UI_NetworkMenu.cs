using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.SceneManagement;

public class UI_NetworkMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void HostButton()
    {
        NetworkManager.Singleton.StartHost();
        NetworkSceneManager.SwitchScene("MainScene");
        return;
    }

    public void ClientButton()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        NetworkManager.Singleton.StartClient();
        return;
    }
    
    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}