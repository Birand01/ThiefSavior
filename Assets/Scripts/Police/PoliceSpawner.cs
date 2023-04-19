using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(PolicePool))]
public class PoliceSpawner : SpawnBase
{
    public delegate void OnPoliceCounterTextHandler(int value);
    public static event OnPoliceCounterTextHandler OnPoliceCounterText;

    public delegate void OnLevelSuccessfullyEndHandler();
    public static event OnLevelSuccessfullyEndHandler OnLevelSuccessfullyEnd;



    [SerializeField] protected Transform spawnPointParent;
    private List<Transform> spawnList = new List<Transform>();
    private PolicePool policePool;
    protected override void Awake()
    {
        base.Awake();
        policePool = GetComponent<PolicePool>();
        spawnPointParent = GameObject.FindGameObjectWithTag("PoliceSpawnPoints").transform;
        for (int i = 0; i < spawnPointParent.childCount; i++)
        {
            spawnList.Add(spawnPointParent.GetChild(i));
        }
    }
    protected override void Start()
    {
        base.Start();
        policePool.Inýtýalize(objectPrefab,totalNumberObjectToSpawn);
    }
    private void OnEnable()
    {
        PoliceHealth.OnDecreasePoliceAmount += DecreasePoliceNumber;
    }

    public override void SpawnAction()
    {
        int spawnPointIndex=Random.Range(0, spawnList.Count);
        GameObject police = policePool.CreateObject(spawnList[spawnPointIndex]);
        //police.transform.position = spawnList[spawnPointIndex].localPosition;
        //police.transform.rotation = Quaternion.identity;
        //GameObject police = Instantiate(objectPrefab,
        //   spawnList[spawnPointIndex].position, Quaternion.identity);

        OnPoliceCounterText.Invoke(spawnedObjectNumber);
    }

    private void DecreasePoliceNumber(int a)
    {
        spawnedObjectNumber-=a;
        LevelEnd();
        OnPoliceCounterText.Invoke(spawnedObjectNumber);
    }
    private void LevelEnd()
    {
        if(spawnedObjectNumber==0)
        {
            OnLevelSuccessfullyEnd?.Invoke();

        }
    }

    //private void OnDisable()
    //{
    //    PoliceHealth.OnDecreasePoliceAmount -= DecreasePoliceNumber;

    //}

}
