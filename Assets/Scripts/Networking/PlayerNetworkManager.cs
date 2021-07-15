// networking 
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

// standard
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkManager : NetworkBehaviour
{
    public NetworkVariableInt networkMove = new NetworkVariableInt(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        });
    public NetworkVariableBool hostTurn = new NetworkVariableBool(new NetworkVariableSettings
    {
        WritePermission = NetworkVariablePermission.ServerOnly,
        ReadPermission = NetworkVariablePermission.Everyone
    });

    void Start()
    {
        networkMove.Value = -1;
        hostTurn.Value = true;
    }

    [ServerRpc(RequireOwnership = false)]
    public void UpdateTurnServerRpc(int value){UpdateTurn(value);}
    
    public void UpdateTurn(int move)
    {
        hostTurn.Value = !hostTurn.Value;
        networkMove.Value = move;
        Debug.Log("new values: " + hostTurn.Value.ToString() + " : " + networkMove.Value.ToString());
        return;
    }
}
