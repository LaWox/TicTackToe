using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class Board{

    private int[,] gameBoard;

    public Board(){
        gameBoard = new int[3,3];
    }

    public bool addMarker(int row, int col, int player){
       
       if( row == -1 || col == -1){
           return false;
       }

       if(checkPosition(row, col)){
           gameBoard[row,col] = player;
           return true;
       }
       else{
           return false;
       }
    }

    public void resetBoard(){
        gameBoard = new int[3,3];
    }

    private bool checkPosition(int row, int col){
        if(gameBoard[row,col] == 0){
            return true;
        }
        else{
           return false; 
        }
    }

    public int gameCompletion(){   

        /*
        gameCompletion states:
        0 : The game is in progress
        1 : The first player won
        2 : The second player won
        3 : It's a draw
        */ 

        for (int i=0; i<3; i++){
           
            // Horizontal rows
            if((gameBoard[i,0] == gameBoard[i,1]) && (gameBoard[i,1] == gameBoard[i,2])){
                return gameBoard[i,0];
            }

             // Vertical rows
            if((gameBoard[0,i] == gameBoard[1,i]) && (gameBoard[1,i] == gameBoard[2,i])){
                return gameBoard[0,i];
            }

             // Diagonal row - left oriented
            if((gameBoard[0,0] == gameBoard[1,1]) && (gameBoard[1,1] == gameBoard[2,2])){
                return gameBoard[0,0];
            }

              // Diagonal row - right oriented
            if((gameBoard[2,0] == gameBoard[1,1]) && (gameBoard[1,1] == gameBoard[0,2]))
            {
                return gameBoard[2,0];
            }

        }
        
        // Check if it is a draw
        int emptyCells = 0;
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(gameBoard[i,j]==0){
                    emptyCells += 1;
                }
            }
        }
        if(emptyCells==0){
            return 3;
        }
        else{
            return 0;
        }

    }

    public void printBoard(){
        string txt="";
        for(int i=0; i<3; i++){
            txt += gameBoard[i,0].ToString()+" "+gameBoard[i,1].ToString()+" "+gameBoard[i,2].ToString()+" \n";
        }
        MonoBehaviour.print(txt);
    }


    static void Main(string[] args) {
        

    }
    
}