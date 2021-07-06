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
    Board board;
    public Board Board{get; set;}

    // int to hold on to chosen position
    int placement;
    int[] placementMat;

    void Start()
    {
        board = new Board();
        // create new player obj and assign numbers
        playerOne = transform.GetChild(0).GetComponent(typeof(LocalPlayer)) as LocalPlayer;
        playerOne.PlayerNum = 1;
        playerTwo = transform.GetChild(1).GetComponent(typeof(LocalPlayer)) as LocalPlayer;
        playerTwo.PlayerNum = 2;
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

            if(board.addMarker(placementMat[0], placementMat[1], activePlayer.PlayerNum));
            {
                board.printBoard();
                activePlayer = playerOneTurn ? playerOne : playerTwo;
                playerOneTurn = !playerOneTurn;
            }   
        }
    }


    public int[] arrayToMatrixIdx(int i)
    {
        int row = 0 / 3;
        int col = i % 3;
        int[] retArr = {row, col}; 
        return retArr;
    }
}
