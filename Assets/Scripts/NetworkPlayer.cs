using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class NetworkPlayer : Player
{
    // Start is called before the first frame update
    PlayerNetworkManager playerNM;
    UserInput userInput;
    private int localMove;
    public int LocalMove{get; set;} 
   
    void Start()
    {   
        playerNM = gameObject.transform.parent.gameObject.GetComponent<Controller>().playerNMComponent;
        userInput = gameObject.GetComponentInParent<UserInput>();
        localMove = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int getMove()
    {
        // if you are the host, you controll player one
        if(playerNM.hostTurn.Value && NetworkManager.Singleton.IsHost && PlayerNum == 1)
        {
            //Debug.Log("host turn");
            localMove = userInput.GetMouseInteraction();
        }
        // the client controlls player two 
        else if(!playerNM.hostTurn.Value && !NetworkManager.Singleton.IsHost && PlayerNum == 2)
        {
            localMove = userInput.GetMouseInteraction();
        }
        // when its the other persons turn
        else 
        {
            localMove = playerNM.networkMove.Value;
        }
        return localMove;
    }
}
