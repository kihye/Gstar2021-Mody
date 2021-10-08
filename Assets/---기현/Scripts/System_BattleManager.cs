using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_BattleManager : MonoBehaviour
{
    public Player_BattleData pData;
    public Enemy_BattleData[] eData = new Enemy_BattleData[4];
    public System_SkillDictionary sDict;

    public int skillCount = 2;
    public int targetEnemy;

    public int enemyCount;
    public int[] diceCount = new int[2];

    private int enemySeed;
    private int _turnCount;

    public int turnCount
    {
        get { return _turnCount; }
        set
        {
            if (value != _turnCount) // turn값이 변할때마다 함수 호출
            {
                _turnCount = value;
                RollDice();
                SetEnemyAIs(enemyCount);
            }
        }
    }
    private void Awake()
    {
        sDict = GameObject.Find("SkillDictionary").GetComponent<System_SkillDictionary>();
        enemyCount = 3;
        pData = new Player_BattleData();
        for(int i = 0; i < enemyCount; i++)
        {
            eData[i] = new Enemy_BattleData();
            eData[i].Set_AI();
        }
        targetEnemy = 0;
        turnCount = 1;
        RollDice();
    }
    void Start()
    {
        //Debug.Log(pData._atkPoint);
    }

    void Update()
    {
        SelectTargetControl();
    }
    public void DoAttack(ref int enemyHp, int myDamage)
    {
        enemyHp = enemyHp - myDamage;
    }
    public void CalAttackDamage()                                   // 일반 공격
    {
        if (eData[targetEnemy].isAlive)
        {
            int eHp = eData[targetEnemy]._targetHp;
            DoAttack(ref eHp, pData._atkPoint);

            eData[targetEnemy]._targetHp = eHp;
            while (!eData[targetEnemy].isAlive && !IsCleared())
            {
                if (targetEnemy + 1 > enemyCount - 1) targetEnemy = 0;
                else targetEnemy++;
            }
            turnCount++;
        }

    }
    public void CalAttackDamage(int sIndex)     // 스킬 공격
    {
        if(eData[targetEnemy].isAlive)
        {
            for(int i = 0; i < sDict.skillDatas[sIndex]._sHitCount; i++)
            {
                int eHp = eData[targetEnemy]._targetHp;
                DoAttack(ref eHp, sDict.skillDatas[sIndex].CalculateSkillDamage(diceCount[0] + diceCount[1]));

                eData[targetEnemy]._targetHp = eHp;
                while (!eData[targetEnemy].isAlive && !IsCleared())
                {
                    if (targetEnemy + 1 > enemyCount - 1) targetEnemy = 0;
                    else targetEnemy++;
                }
            }
            turnCount++;
        }
        
    }
    private void SelectTargetControl()
    {
        if(enemyCount > 1 && !IsCleared())
        {
            bool isSelected = false;
            if (Input.GetKeyDown(KeyCode.A))
            {
                while(!isSelected)  // 사망한 적 타겟팅 안되게 제어
                {
                    if (targetEnemy - 1 < 0) targetEnemy = enemyCount - 1;
                    else targetEnemy--;

                    if (eData[targetEnemy].isAlive) isSelected = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                while(!isSelected)  // 위와 기능 동일
                {
                    if (targetEnemy + 1 > enemyCount - 1) targetEnemy = 0;
                    else targetEnemy++;

                    if (eData[targetEnemy].isAlive) isSelected = true;
                }
            }
        }
        
    }
    private void RollDice()
    {
        for(int i = 0; i < 2; i++)
        {
            diceCount[i] = Random.Range(1, 7);
        }
        sDict.thisDiceCount = diceCount[0] + diceCount[1];
    }
    private void SetEnemyAIs(int enemyNum)
    {
        for(int i = 0; i < enemyNum; i++)
        {
            if (eData[i].isAlive)
            {
                eData[i].Active_AI(ref pData._curHp);
                eData[i].Set_AI();
            }
        }
    }
    public bool IsCleared()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            if (eData[i].isAlive)
                return false;
        }
        return true;
    }
}