using MLAPI;
using MLAPI.Logging;
using MLAPI.Spawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // -------------- Player Objects n stuff -------------------
    Player playerOne, playerTwo;
    // Player prefabs 
    public GameObject playerPrefab, playerNMPrefab;
    // player Game objects
    [HideInInspector]
    public GameObject playerOneGO, playerTwoGO;

    // Controll the pause state of the game
    PauseControll pauseControll;
    // keep track of player turn
    Player activePlayer;
    bool playerOneTurn;
    
    // ----------------- Networking ----------------
    NetworkObject localPlayer;
    GameObject playerNMObj;
    
    [HideInInspector]
    public PlayerNetworkManager playerNMComponent;
    public HashSet<NetworkObject> spawnedObjects;

    // ------------- Game Logic --------------------
    DataManager data;  
    // board 
    public Board board;
    //public Board Board{get; set;}
    VisualBoard visualBoard;

    // int to hold on to chosen position
    int placement;
    int[] placementMat;


    void Start()
    {   
        board = new Board();
        visualBoard = (VisualBoard) GameObject.Find("Board1").GetComponent<VisualBoard>();
        pauseControll = gameObject.GetComponent<PauseControll>();
        
        // Load levelData
        data = GameObject.Find("DataManager").GetComponent<DataManager>();

        // init Player game objects
        playerOneGO = new GameObject();
        playerTwoGO = new GameObject();
        playerOneGO.name = "PlayerOne";
        playerTwoGO.name = "PlayerTwo";
        playerOneGO.transform.parent = gameObject.transform;
        playerTwoGO.transform.parent = gameObject.transform;

        // assign player types
        switch (data.activeGameMode)
        {
            case DataManager.GameMode.Local:
                playerOne = playerOneGO.AddComponent<LocalPlayer>();
                playerTwo = playerTwoGO.AddComponent<LocalPlayer>();
                break;
            case DataManager.GameMode.AI:
                playerOne = playerOneGO.AddComponent<LocalPlayer>();
                playerTwo = playerTwoGO.AddComponent<AIPlayer>();
                break;
            case DataManager.GameMode.Online:
                // get local player object 
                localPlayer = NetworkSpawnManager.GetLocalPlayerObject();
                
                playerOne = playerOneGO.AddComponent<NetworkPlayer>();
                playerTwo = playerTwoGO.AddComponent<NetworkPlayer>();

                // Place holder for spawned objects
                spawnedObjects = NetworkSpawnManager.SpawnedObjectsList;
                if(NetworkManager.Singleton.IsHost)
                {
                    // create and spawn a player network manager 
                    playerNMObj = Instantiate(playerNMPrefab);
                    playerNMObj.GetComponent<NetworkObject>().Spawn();
                    playerNMComponent = playerNMObj.GetComponent<PlayerNetworkManager>();                    
                }
                else
                {          
                    // Find the playerNetworkManager from spawned objects         
                    foreach (var item in spawnedObjects)
                    {
                        if(item.GetComponent<PlayerNetworkManager>())
                        {
                            playerNMObj = item.gameObject;
                            playerNMComponent = playerNMObj.GetComponent<PlayerNetworkManager>();

                        }
                    }
                }
                break;
        }

        // set up player one
        playerOne.PlayerNum = 1;
        playerOne.PlayerSymbol="3D Objects/apple";

        // set up player two
        playerTwo.PlayerNum = 2;
        playerTwo.PlayerSymbol="3D Objects/banana";
        
        // first player starts starts as active player
        activePlayer = playerOne;
        playerOneTurn = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        // skip Update if isPaused
        if(pauseControll.isPaused)
        {
            return;
        }
        // get move from active player
        UpdateLocal();
      
        // different scenarios for winns
        if(board.gameCompletion() != 0){
            if(board.gameCompletion() == 1){
                print("Player 1 wins");
                
            }
            else if(board.gameCompletion() == 2){
                print("Player 2 wins");
            }
            else{
                print("It's a draw");
            }
            print("Game restarts...");
            StartCoroutine(RestartGame(5));            
        }
    }

    private void UpdateLocal()
    {
        placement = activePlayer.getMove();
        if(placement != -1)
        {   
            placementMat = arrayToMatrixIdx(placement);
            // returns true if move passed 
            bool markerState = board.addMarker(placementMat[0], placementMat[1], activePlayer.PlayerNum);          
            if(markerState){
                // spawn a symbol for corresponding player
                visualBoard.cells[placement].GetComponent<VisualCell>().SpawnPiece(activePlayer.PlayerSymbol);
                
                // if we are playing online, update the online board state
                if(data.activeGameMode == DataManager.GameMode.Online)
                {
                    UpdateOnline(placement);
                }

                playerOneTurn = !playerOneTurn;
                activePlayer = playerOneTurn ? playerOne : playerTwo;                 
            }   
        }
        return; 
    }

    private void UpdateOnline(int move)
    {
       if(NetworkManager.Singleton.IsHost && activePlayer == playerOne)
       {
           playerNMComponent.UpdateTurn(move);
       }
       else if(!NetworkManager.Singleton.IsHost && activePlayer == playerTwo)
       {
           playerNMComponent.UpdateTurnServerRpc(move);
       }
       else
       {
           return;
       }
    }

    IEnumerator AIDelay(int time){
            
            yield return new WaitForSecondsRealtime(time);
            visualBoard.cells[placement].GetComponent<VisualCell>().SpawnPiece(activePlayer.PlayerSymbol);

    }

    IEnumerator RestartGame(int time){
            print("Restarting in "+time.ToString()+" seconds");
            //yield return new WaitForSeconds(time);
            for(int i=1; i<time; i++){
                print(i.ToString());
                yield return new WaitForSeconds(1);

            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     
    }


    public int[] arrayToMatrixIdx(int i)
    {
        int row = i / 3;
        int col = i % 3;
        int[] retArr = {row, col}; 
        return retArr;
    }
}
