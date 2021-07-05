using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Board b = new Board();
        b.printBoard();
        b.addMarker(-1,0,1);
        b.addMarker(0,-1,1);
        b.addMarker(0,2,1);
        b.printBoard();
        print(b.gameCompletion());

        b.resetBoard();
        b.printBoard();
        b.addMarker(0,0,2);
        b.addMarker(0,1,2);
        b.addMarker(0,2,2);
        b.printBoard();
        print(b.gameCompletion());
        b.resetBoard();
        b.addMarker(0,0,1);
        b.addMarker(0,1,2);
        b.addMarker(0,2,2);

        b.addMarker(1,0,2);
        b.addMarker(1,1,1);
        b.addMarker(1,2,1);

        b.addMarker(2,0,1);
        b.addMarker(2,1,2);
        b.addMarker(2,2,2);

        b.printBoard();
        print(b.gameCompletion());
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            print(KeyCode.Keypad0);
        }
        
    }
}
