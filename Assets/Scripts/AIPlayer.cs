using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    Board currentBoard;
    void Start()
    {
        currentBoard = (gameObject.GetComponentInParent(typeof(Controller)) as Controller).Board;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override int getMove()
    {
        return -1;
    }

    private int CalcScore() // calculates score board state
    {
        List<int> markerPos = new List<int>(); // store pos of found markers

        for(int row = 0; row < 3; row++)
        {
            for(int col = 0; col < 3; col++)
            {
                // check board
                if(currentBoard.GameBoard[row,col] == this.PlayerNum)
                {
                    markerPos.Add(row*3 + col);
                }
            }
        }
        return 0;
    }
}
