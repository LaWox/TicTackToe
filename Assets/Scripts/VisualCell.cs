using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCell : MonoBehaviour
{

    public int CellNumber {get; set;}
    public GameObject Object {get; set;}

    void ChangeAppereance(){

    }

    void PrintCell(){
        print("This is cell number: "+CellNumber.ToString());
    }
    
    void SpawnPiece(string path){
        GameObject prefab = (GameObject) Resources.Load(path);
        Vector3 pos = Object.transform.position+ new Vector3(0f,0f,0.2f);
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
