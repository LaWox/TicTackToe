using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    // Start is called before the first frame update
    KeyCode[] myKeys;
    int pressedKey;
    void Start()
    {
        myKeys = new KeyCode[9];
        myKeys[0] = KeyCode.Alpha0;
        myKeys[1] = KeyCode.Alpha1;
        myKeys[2] = KeyCode.Alpha2;
        myKeys[3] = KeyCode.Alpha3;
        myKeys[4] = KeyCode.Alpha4;
        myKeys[5] = KeyCode.Alpha5;
        myKeys[6] = KeyCode.Alpha6;
        myKeys[7] = KeyCode.Alpha7;
        myKeys[8] = KeyCode.Alpha8;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public int getUserInput()
    {
        int userInput = -1;
        if(Input.anyKey)
        {    
            for(int i = 0; i < myKeys.Length; i++)
            {
                if(Input.GetKeyDown(myKeys[i]))
                {
                    userInput = i;
                    Debug.Log(i);
                }
            }
        }
        
        return userInput;
    }
    public int GetMouseInteraction()
    {
        if (Input.GetMouseButtonDown(0)) // if left button pressed...
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Cell")
            {
               return (hit.transform.gameObject.GetComponent<VisualCell>()).CellNumber;
            }
        }
        return -1;
    }
}
