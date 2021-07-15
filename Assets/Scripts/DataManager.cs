using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public enum GameMode
    {
        Local,
        AI,
        Online
    }
    public GameMode activeGameMode;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        activeGameMode = GameMode.Local;
    }
}
