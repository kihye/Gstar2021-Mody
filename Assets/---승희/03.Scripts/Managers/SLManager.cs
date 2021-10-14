using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataInfo
{
    public string name;

    public int maxHp;
    public int curHp;

    public int atkPoint;
    public int defPoint;

    public int playerMoney;
    public Stack<Node> nodeData = new Stack<Node>();

    public Vector3 playerPos;

    public DataInfo(System_MainDataManager dm)
    {
        DataRenew(dm);
    }
    public void DataRenew(System_MainDataManager dm)
    {
        name = dm.name;

        maxHp = dm.maxHp;
        curHp = dm.curHp;

        atkPoint = dm.atkPoint;
        defPoint = dm.defPoint;

        playerMoney = dm.playerMoney;
        nodeData = dm.nodeData;
        playerPos = dm.playerPos;
    }
}

public class SLManager : MonoBehaviour
{
    public static SLManager instance;
    DataInfo data;
    //DataInfo data = new DataInfo(System_MainDataManager.mainData);

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }
    }

    
    public void SaveData(DataInfo _data)
    {
        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.dataPath + "/SaveDataInfo.json", jsonData);
    }

    public void LoadData()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/SaveDataInfo.json");

        data = JsonUtility.FromJson<DataInfo>(jsonData);
    }

    public void DeleteData()
    {
        File.Delete(Application.dataPath + "/SaveDataInfo.json");
    }

    public bool SearchData()
    {
        bool fileExist = File.Exists(Application.dataPath + "/SaveDataInfo.json") ? true : false;
        return fileExist;
    }
}
