using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    // number of the player ie., first or second
    private int playerNum;
    public int PlayerNum{get; set;}

    public string PlayerSymbol{get; set;}

    // returns a number indicating where to place symbol
    public abstract int getMove();
}
