using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ReturnButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NetworkMenu, MainMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReturnButton()
    {
        if(NetworkMenu.active)
        {
            NetworkMenu.active = false;
            MainMenu.active = true;
        }
        else
        {
            return;
        }
    }
}
