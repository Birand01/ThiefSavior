using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void OnLevelStartHandler(LevelData levelData);
    public static event OnLevelStartHandler OnLevelStart;
    public delegate void OnLevelEndHandler(bool levelCompleted);
    public static event OnLevelEndHandler OnLevelEnd;
    private void Awake()
    {
        PoliceSpawner.OnLevelSuccessfullyEnd += EndLevel;
        OnLevelStart += SetUpLevel;
    }

    public static void StartLevel(LevelData data)
    {
        OnLevelStart?.Invoke(data);
    }
    private void EndLevel()
    {
        PoliceSpawner.OnLevelSuccessfullyEnd -= EndLevel;
        OnLevelStart -= SetUpLevel;
        OnLevelEnd?.Invoke(true);
    }
    private void SetUpLevel(LevelData levelData)
    {
        
        if (levelData != null)
        {
           
            GameObject level = Instantiate(levelData.levelPrefab);
            level.transform.position = new Vector3(0, 0, 0);
            level.transform.rotation = Quaternion.identity;
        }
        else

        return;

    }

   

    //private void ClearPreviousLevel()
    //{
    //    for (int i = 0; i < levelCatalog.Length; i++)
    //    {
    //        levelCatalog.GetLevel(i).levelPrefab.gameObject.SetActive(false);

    //    }
    //}


}
