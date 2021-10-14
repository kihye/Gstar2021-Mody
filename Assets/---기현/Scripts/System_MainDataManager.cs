using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_MainDataManager : MonoBehaviour
{
    public static System_MainDataManager mainData;

    public string name;
    public int maxHp;
    public int curHp;
    public int atkPoint;
    public int defPoint;

    public int playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        if (mainData == null)
        {
            mainData = this;
            DontDestroyOnLoad(mainData);
        }
        else
        {
            Destroy(mainData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNewGame()
    {
        maxHp = 200;
        curHp = maxHp;
        atkPoint = 10;
        defPoint = 10;

        playerMoney = 0;
    }
}
