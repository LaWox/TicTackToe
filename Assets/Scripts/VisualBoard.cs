using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBoard : MonoBehaviour
{

    public GameObject[] cells = new GameObject[9];
    public Material cellMaterial;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=1; i<10; i++){
            var cell = GameObject.Find("Cell"+i.ToString());
            cell.tag = "Cell";
            cell.AddComponent<VisualCell>();
            cell.GetComponent<VisualCell>().CellNumber=i-1;
            cell.GetComponent<MeshRenderer>().material=cellMaterial;
            cells[i-1]=cell;
        }
    }

}
