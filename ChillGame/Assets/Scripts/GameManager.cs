using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum GAMESTATE
{
    INIT,
    LOADING,
    GAMEPLAY,
    PAUSE,
    EXIT,
    MAIN_MENU,
    NONE
}

 
public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public Action<GAMESTATE> onActionChange;
    public GAMESTATE gameState {
        get;
        set;
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _instance = this;
    }

    public static GameManager Instance
    {
        get => _instance == null ? _instance = new GameManager() : _instance;
    }

    public void SetStateChange(GAMESTATE gamestate)
    {
        gameState = gamestate;
        onActionChange?.Invoke(gamestate);
        Debug.Log("State change: " + gameState);
    }

    public void OnApplicationQuit()
    {
        _instance = null;
    }

 

    public void EndGame()
    {
    }    
 
}
