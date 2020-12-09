using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstGamePositionStart : MonoBehaviour
{

    public void NewGameOnClicked()
    {
        GameManager.Instance.SetStateChange(GAMESTATE.MAIN_MENU);
        SceneManagerCommon.LoadSceneFromSceneManager(1);
    }

    public void ExitGameOnClicked()
    {
        GameManager.Instance.SetStateChange(GAMESTATE.EXIT);
    }

    private void Update()
    {
        GameManager.Instance.onActionChange = (action) =>
        {
            if (action == GAMESTATE.EXIT)
            {
                Debug.Log("Exit");
            }
        };
    }
}
