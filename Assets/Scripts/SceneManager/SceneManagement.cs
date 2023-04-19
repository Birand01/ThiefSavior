using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public delegate void OnSceneCounterHandler(int index);
    public static event OnSceneCounterHandler OnSceneCounter;
    private int currentLevelNumber;
    private void OnEnable()
    {
        PoliceSpawner.OnLevelSuccessfullyEnd += CurrentLevelNumber;
    }
   

    public void LoadNextLevel()
    {      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(SceneManager.GetActiveScene().buildIndex==3)
        {
           SceneLoader.LoadScene(SceneName.LevelEnd);
        }
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);

    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu()
    {
        SceneLoader.LoadScene(SceneName.MainMenu);

    }

    private void CurrentLevelNumber()
    {
        currentLevelNumber = SceneManager.GetActiveScene().buildIndex;
        OnSceneCounter(currentLevelNumber);
    }
    private void OnDisable()
    {
        PoliceSpawner.OnLevelSuccessfullyEnd -= CurrentLevelNumber;

    }

}
