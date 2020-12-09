using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderCommon : MonoBehaviour
{
    public void BackSceneClicked()
    {
        SceneManagerCommon.LoadPreviousSceneManager();
    } 
    
    public void RedirectToSceneClicked(string nameScene)
    {
        SceneManagerCommon.LoadSceneFromSceneManager(name);
    }    
}
