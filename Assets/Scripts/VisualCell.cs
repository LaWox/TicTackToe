using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCell : MonoBehaviour
{

    public int CellNumber {get; set;}
    

    public void ChangeAppereance(){

    }

    public void PrintCell(){
        print("This is cell number: "+CellNumber.ToString());
    }
    
    public void SpawnPiece(string path){
        GameObject prefab = (GameObject) Resources.Load(path);
        Vector3 pos = this.transform.position+ new Vector3(0f,19f,0f);
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
