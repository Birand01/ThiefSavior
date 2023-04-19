using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public static void LoadScene(SceneName name)
    {
        SceneManager.LoadScene((int)name);
    }
}
public enum SceneName
{
    MainMenu,
    Level,
    LevelEnd
}
