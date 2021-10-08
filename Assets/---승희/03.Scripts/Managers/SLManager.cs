using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataInfo
{
    public string name;
    public int money;
    public int debt;

    public DataInfo(string _name, int _money, int _dept)
    {
        name = _name;
        money = _money;
        debt = _dept;
    }
}

public class SLManager : MonoBehaviour
{
    public static SLManager instance;

    DataInfo data = new DataInfo("디폴트", 0, 0);

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
        data.name = _data.name;
        data.money = _data.money;
        data.debt = _data.debt;

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
