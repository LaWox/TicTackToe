using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MLAPI;
using MLAPI.SceneManagement;
using MLAPI.Messaging;
public class OnConnection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // if you are the host
        if(NetworkManager.Singleton.IsHost)
        {
            if(NetworkManager.Singleton.ConnectedClientsList.Count > 1)
            {
                UpdateScene();
            }
        }
        // if a you are not host and a server is running
        else if(NetworkManager.Singleton.IsServer)
        {
            
            RequestSceneChangeServerRpc();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ServerRpc(RequireOwnership = false)]
    public void RequestSceneChangeServerRpc()
    {
        UpdateScene();
    }
    private void UpdateScene()
    {
        NetworkSceneManager.SwitchScene("MainScene");
    }
}
