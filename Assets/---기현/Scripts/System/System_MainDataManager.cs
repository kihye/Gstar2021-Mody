using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_MainDataManager : MonoBehaviour
{
    public bool isDebugMode;
    public const int MaxSkillNum = 4;

    public static System_MainDataManager mainData;

    public string name = "";
    public int maxHp;
    public int curHp;
    public int atkPoint;
    public int defPoint;

    public int playerMoney;
    public int playerDebt;

    public int playerTurn;

    public bool[] skillUnlocked = new bool[MaxSkillNum];
    public Stack<Node> nodeData = new Stack<Node>();

    public Transform playerTransform;
    public Vector3 playerPos;

    public static int fieldEnemyData;
    public bool isBattleScene = false;

    // 개조 부분
    public bool rm_IQM = false;

    // Start is called before the first frame update
    void Awake()
    {
        //StartNewGame();
    }
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
    private void RemodelingInitialize()
    {
        rm_IQM = false;
    }
    public void DeadControl()
    {
        curHp = maxHp;
        playerPos.x = 30;
        playerPos.y = 15;
        playerPos.z = 140;
    }
    // Update is called once per frame
    public void StartNewGame()
    {
        maxHp = 200;
        curHp = maxHp;
        atkPoint = 50;
        defPoint = 5;

        playerTurn = 1;
        playerMoney = 10000000;
        playerDebt = 1000000000;
        // 시작 지점
        playerPos.x = 30;
        playerPos.y = 15;
        playerPos.z = 140;

        RemodelingInitialize();
        RemodelShopData.instance.InitializeData();

        for (int i = 0; i < MaxSkillNum; i++)
        {
            if (i < 4)
                skillUnlocked[i] = true;
            else
                skillUnlocked[i] = false;
        }
    }
    public string MoneyText(int num)
    {
        if (num <= 0)
            return "0";
        return string.Format("{0:#,###}", num);
    }
}
