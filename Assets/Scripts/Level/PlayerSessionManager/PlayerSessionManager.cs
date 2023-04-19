using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSessionManager : MonoBehaviour
{
   public static PlayerSessionManager instance;
    public LevelCatalog levelCatalog;
    int currentLevel=0;
   
    private void Awake()
    {
        Debug.Log(currentLevel);

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }else if(instance!=this)
        { Destroy(gameObject); }
        SceneManager.sceneLoaded += OnSceneLoad;
        LevelManager.OnLevelEnd += HandleLevelEnd;

    }

    private void OnSceneLoad(Scene s,LoadSceneMode lsm)
    {

        if(s.name=="Level")
        {
            LevelManager.StartLevel(levelCatalog.GetLevel(currentLevel));
        }
    }
    private void HandleLevelEnd(bool levelCompleted)
    {
        ClearLevelData(levelCatalog);
        if (levelCompleted)
        {         
            currentLevel = (currentLevel + 1) % levelCatalog.Length;
            if(currentLevel==levelCatalog.Length)
            {
                Debug.Log("ALL LEVELS ARE COMPLETED");
            }
        }
        StartCoroutine(LoadLevelEndScene());
    }

    private IEnumerator LoadLevelEndScene()
    {
        yield return new WaitForSeconds(3f);
        SceneLoader.LoadScene(SceneName.LevelEnd);
    }
    private void ClearLevelData(LevelCatalog levelCatalog)
    {      
            levelCatalog.GetLevel(currentLevel).levelPrefab.SetActive(false);
    }

    //private void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoad;
    //    LevelManager.OnLevelEnd -= HandleLevelEnd;
    //}
}
