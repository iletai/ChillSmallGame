using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAMESTATE
{
    LOADING,
    GAMEPLAY,
    PAUSE,
    EXIT,
    MAIN_MENU,
    NONE
}

public delegate void OnSateChangeHandler();

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public event OnSateChangeHandler onGameStateChange;
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
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public void SetStateChange(GAMESTATE gamestate)
    {
        gameState = gamestate;
        Debug.Log("Set state: " + gameState);
    }

    public void OnApplicationQuit()
    {
        _instance = null;
    }

}
