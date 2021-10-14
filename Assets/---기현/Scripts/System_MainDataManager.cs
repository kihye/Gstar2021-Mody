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
    public Stack<Node> nodeData = new Stack<Node>();

    public Transform playerTransform;
    public Vector3 playerPos;

    public int fieldEnemyData;
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
        // 시작 지점
        playerPos.x = 45;
        playerPos.y = 5;
        playerPos.z = -45;
    }
    public void PlayerPosSet()
    {

    }
}
