using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBoard : MonoBehaviour
{

    public VisualCell[] cells = new VisualCell[9];
    // Start is called before the first frame update
    void Awake()
    {
        for(int i=1; i<10; i++){
            var cell = GameObject.Find("Cell"+i.ToString());
            cells[i-1].Object=cell;
            cells[i-1].CellNumber=i;
        }
    }

}
