using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MLAPI;

public class UI_ReturnButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject networkMenu, mainMenu, waitForConnection, title;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReturnButton()
    {
        if(networkMenu.active || waitForConnection.active)
        {
            waitForConnection.active = false;
            networkMenu.active = false;
            mainMenu.active = true;
            title.active = true;

            if(NetworkManager.Singleton.IsServer)
            {
                NetworkManager.Singleton.StopHost();
            }
            else if(NetworkManager.Singleton.IsClient)
            {
                NetworkManager.Singleton.StopClient();
            }
        }
        else
        {
            return;
        }
    }
}
