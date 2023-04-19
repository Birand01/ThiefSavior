using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DataFile", menuName = "DataFile/LevelCatalog", order = 1)]
public class LevelCatalog : ScriptableObject
{
    [SerializeField] LevelData[] levels;


    public int Length
    {
        get { return levels.Length; }
    }
    public LevelData GetLevel(int index)
    {
        if(index>=levels.Length || index<0)
        {
            return null;
        }
        return levels[index];  
    }

    public int GetIndexOfLevel(LevelData data)
    {
        return Array.IndexOf(levels,data);
    }
}
