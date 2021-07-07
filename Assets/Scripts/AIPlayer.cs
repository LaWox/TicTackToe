using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    Board currentBoard;
    Controller controller;
    void Start()
    {
        controller = gameObject.GetComponentInParent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
      // kommentar  
    }
    public override int getMove()
    {
        return RandomMove();
    }

    private int RandomMove()
    {
        int row, col;
        currentBoard = controller.board;
        for(int i = 0; i < 100; i++)
        {
            row = Random.Range(0, 3);
            col = Random.Range(0, 3);
            
            if(currentBoard.gameBoard[row, col] == 0)
            {
                
                return row* 3 + col;
            }
        }
        return -1;
    }


    private int CalcScore() // calculates score board state
    {
        List<int> markerPos = new List<int>(); // store pos of found markers
        if(currentBoard.gameCompletion() == this.PlayerNum)
        {
            // if won return big number
            return 10000;
        }

        for(int row = 0; row < 3; row++)
        {
            for(int col = 0; col < 3; col++)
            {
                // check board
                if(currentBoard.gameBoard[row, col] == this.PlayerNum)
                {
                    markerPos.Add(row*3 + col);
                }
            }
        }
        // loop through marker positions
        for(int i = 0; i < markerPos.Count; i++)  
        {
            int curr = markerPos[i];

        }
        return 0;
    }
}
