using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerCommon : MonoBehaviour
{
    private static bool _hasDestroyed = false;
    private static object _lockObject = new object();

    private static SceneManagerCommon _instance;

    private Stack<int> _loaderLevelStack;

    public static SceneManagerCommon Instance
    {
        get
        {
            if (_hasDestroyed)
            {
                Debug.LogWarning("[Instance: " + typeof(SceneManagerCommon) + "has been destroyed. Return null!");
                return null;
            }

            lock(_lockObject)
            {
                _instance = (SceneManagerCommon)FindObjectOfType(typeof(SceneManagerCommon));
                if (_instance == null)
                {
                    var singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<SceneManagerCommon>();
                    singletonObject.name = typeof(SceneManagerCommon).ToString() + " Singleton";
                    DontDestroyOnLoad(singletonObject);
                }
                return _instance;
            }    
        }
    }

    public static Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }    

    public static void LoadSceneFromSceneManager(int buildIndex)
    {
        Instance._loaderLevelStack.Push(GetActiveScene().buildIndex);
        SceneManager.LoadScene(buildIndex);
    }    
    public static void LoadSceneFromSceneManager(string sceneName)
    {
        Instance._loaderLevelStack.Push(GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneName);
    } 
    
    public static void LoadPreviousSceneManager()
    {
        if (Instance._loaderLevelStack.Count > 0)
        {
            SceneManager.LoadScene(Instance._loaderLevelStack.Pop());
        }
    }

    private void Awake()
    {
        _loaderLevelStack = new Stack<int>();
    }

    private void OnApplicationQuit()
    {
        _hasDestroyed = true;
    }

    private void OnDestroy()
    {
        _hasDestroyed = true;
    }
}
