using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBoard : MonoBehaviour
{

    public GameObject[] cells = new GameObject[9];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=1; i<10; i++){
            var cell = GameObject.Find("Cell"+i.ToString());
            cell.AddComponent<VisualCell>();
            cell.GetComponent<VisualCell>().CellNumber=i-1;
            cells[i-1]=cell;
        }
    }

}
