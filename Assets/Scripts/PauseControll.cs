using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControll : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool isPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TogglePaus()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
        }
    }
}
