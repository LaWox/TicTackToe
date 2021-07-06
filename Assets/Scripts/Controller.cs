using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // player objects
    Player playerOne, playerTwo;
    Player activePlayer;
    // keep track of player turn 
    bool playerOneTurn;
    LevelData levelData;
    
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
        // Load levelData
        levelData = Resources.Load<LevelData>("Data/LevelData");
        // create new player obj and assign numbers
        playerOne = transform.GetChild(0).GetComponent<LocalPlayer>();
        //Debug.Log(playerOne);
        playerOne.PlayerNum = 1;
        playerOne.PlayerSymbol="3D Objects/TestCube";

        // assign opponent type
        //Debug.Log(levelData.activeMode);
        switch (levelData.activeMode)
        {
            case LevelData.GameMode.Local:
                playerTwo = transform.GetChild(1).gameObject.AddComponent<LocalPlayer>();
                break;
            case LevelData.GameMode.AI:
                playerTwo = transform.GetChild(1).gameObject.AddComponent<AIPlayer>();
                break;
            default:
                playerTwo = transform.GetChild(1).gameObject.AddComponent<LocalPlayer>();
                break;
        }

        Debug.Log(playerTwo);

        playerTwo.PlayerNum = 2;
        playerTwo.PlayerSymbol="3D Objects/TestCylinder";
        activePlayer = playerOne;
        playerOneTurn = true;
    }

    // Update is called once per frame
    void Update()
    {   
        if(board.gameCompletion() != 0){
            return;
        }
        placement = activePlayer.getMove();
        if(placement != -1)
        {   
            placementMat = arrayToMatrixIdx(placement);
            bool markerState = board.addMarker(placementMat[0], placementMat[1], activePlayer.PlayerNum);
            
            if(markerState){
                
                /*if(activePlayer.GetComponent<AIPlayer>() != null){
                    StartCoroutine(AIDelay(5));
                    print("AI player");

                }*/

                visualBoard.cells[placement].GetComponent<VisualCell>().SpawnPiece(activePlayer.PlayerSymbol);
                activePlayer = playerOneTurn ? playerTwo : playerOne;
                playerOneTurn = !playerOneTurn;
            }   
        }
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

    /*IEnumerator AIDelay(int time){
            
            yield return new WaitForSecondsRealtime(time);

    }*/

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
