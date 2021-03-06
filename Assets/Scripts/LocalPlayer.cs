using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : Player
{
    UserInput userInput;

    void Start()
    {
        userInput = gameObject.GetComponentInParent<UserInput>();
    }

    public override int getMove()
    {
        return userInput.GetMouseInteraction();
    }
}
