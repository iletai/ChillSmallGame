using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstGamePositionStart : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Current state: " + GameManager.Instance.gameState);

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void NewGameOnClicked()
    {
        GameManager.Instance.SetStateChange(GAMESTATE.MAIN_MENU);
        SceneManager.LoadScene(1);
    }

    public void ExitGameOnClicked()
    {
        GameManager.Instance.SetStateChange(GAMESTATE.EXIT);
        Application.Quit();
    }    
}
