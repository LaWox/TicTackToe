using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBoard : MonoBehaviour
{

    public GameObject[] cells = new GameObject[9];
    public Material cellMaterial;
    public Material barMaterial;
    // Start is called before the first frame update
    void Start()
    {   
        cellMaterial = (Material) Resources.Load("Materials/Grass");
        barMaterial = (Material) Resources.Load("Materials/Bark/Bark07");
        for(int i=1; i<10; i++){
            var cell = GameObject.Find("Cell"+i.ToString());
            cell.tag = "Cell";
            cell.AddComponent<VisualCell>();
            cell.GetComponent<VisualCell>().CellNumber=i-1;
            cell.GetComponent<MeshRenderer>().material=cellMaterial;
            cells[i-1]=cell;
        }
        for(int i=1; i<5; i++){
            var cell = GameObject.Find("Bar"+i.ToString());
            cell.GetComponent<MeshRenderer>().material=barMaterial;
        }
    }

}
