using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // player objects
    Player playerOne, playerTwo;
    Player activePlayer;
    // keep track of player turn 
    bool playerOneTurn;
    // local, AI, online etc.
    enum GameMode
    {
        Local,
        AI,
        Online
    }
    GameMode currentMode;
    
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
        // create new player obj and assign numbers
        playerOne = transform.GetChild(0).GetComponent(typeof(LocalPlayer)) as LocalPlayer;
        playerOne.PlayerNum = 1;
        playerOne.PlayerSymbol="3D Objects/TestCube";
        playerTwo = transform.GetChild(1).GetComponent(typeof(AIPlayer)) as AIPlayer;
        playerTwo.PlayerNum = 2;
        playerTwo.PlayerSymbol="3D Objects/TestCylinder";
        activePlayer = playerOne;
        playerOneTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        placement = activePlayer.getMove();
        if(placement != -1)
        {   
            
            placementMat = arrayToMatrixIdx(placement);
            board.printBoard();
            //print(placement);
            //print(placementMat[0].ToString()+" "+ placementMat[1].ToString());
            bool markerState = board.addMarker(placementMat[0], placementMat[1], activePlayer.PlayerNum);
            //print(markerState);
            if(markerState){
                //print("hej");
                //board.printBoard();                
                //visualBoard.cells[placement].GetComponent<VisualCell>().PrintCell();
                visualBoard.cells[placement].GetComponent<VisualCell>().SpawnPiece(activePlayer.PlayerSymbol);
                activePlayer = playerOneTurn ? playerTwo : playerOne;
                playerOneTurn = !playerOneTurn;
            }   
        }
    }


    public int[] arrayToMatrixIdx(int i)
    {
        int row = i / 3;
        int col = i % 3;
        int[] retArr = {row, col}; 
        return retArr;
    }
}
