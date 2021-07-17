using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.SceneManagement;

public class UI_NetworkMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject waitForConnection;
    private static string waitMessage = "Wating for ";
    void Start()
    {
        waitForConnection.active = false;
    }

    public void HostButton()
    {
        gameObject.transform.Find("NetworkMenu").gameObject.active = false;
        gameObject.transform.Find("Title").gameObject.active = false;
        waitForConnection.active = true;
        waitForConnection.transform.Find("WaitMessage").gameObject.GetComponent<Text>().text = waitMessage + "client";
        NetworkManager.Singleton.StartHost();
        return;
    }
   
    public void ClientButton()
    {
        gameObject.transform.Find("NetworkMenu").gameObject.active = false;
        gameObject.transform.Find("Title").gameObject.active = false;
        waitForConnection.active = true;
        waitForConnection.transform.Find("WaitMessage").gameObject.GetComponent<Text>().text = waitMessage + "host";
        NetworkManager.Singleton.StartClient();
        return;
    }
}