using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_BattleManager : MonoBehaviour
{
    [SerializeField]
    private UI_Manager uis;

    private Player_Action act;
    private Enemy_Action enemy_Act;
    
    public Vector3 cameraPos;
    public Quaternion cameraRot;
    public GameObject battleCamera;

    public Player_BattleData pData;
    public Enemy_BattleData[] eData = new Enemy_BattleData[4];
    public System_SkillDictionary sDict;
    public System_EnemyDictionary eDict;

    public int enemyActionIndex = 0;

    public int targetEnemy;

    public int enemyCount;
    public int[] diceCount = new int[2];
    public int[] skillCoolTime = new int[4];
    public bool[] skillUsed = new bool[4];

    public int[ , ] buffTimeAndCnt = new int[3, 2];
    // 0 == 공격력, 1 == 방어력, 2 == 체력
    // [ , 0] == 시간, [ , 1] == 수치
    private int enemySeed;
    private int _turnCount;
    private int skillNum;

    public bool isCal = false;
    public bool enemyActed = false;

    public bool isEnemyDead = false;
    public bool isEnemyAttack = false;

    public static bool isPlayerDead = false;

    public float sysActionSpeed = 2f;
    public int turnCount
    {
        get { return _turnCount; }
        set
        {
            if (value != _turnCount) // turn값이 변할때마다 함수 호출
            {
                _turnCount = value;
                RollDice();
                SetEnemyActionIndex(enemyCount);
                act.ResetActionCheck();
                SkillCoolTimeControl();
                for (int i = 0; i < 3; i++)
                {
                    if (buffTimeAndCnt[i, 0] - 1 == 0)
                    {
                        if (i == 0)
                            pData._atkPoint -= buffTimeAndCnt[i, 1];
                        else if (i == 1)
                            pData._defPoint -= buffTimeAndCnt[i, 1];

                        buffTimeAndCnt[i, 0] = 0;
                        buffTimeAndCnt[i, 1] = 0;
                    }
                    else
                    {
                        if(buffTimeAndCnt[i, 0] > 0)
                        {
                            buffTimeAndCnt[i, 0]--;
                        }
                    }             
                }
            }
        }
    }
    public void MakeEnemys(int eSeed, ref int eCount)
    {
        int level = eSeed;
        int enemyIdx;
        switch (level)
        {
            case 0:
                eCount = Random.Range(1, 5);
                break;
            case 1:
                eCount = Random.Range(1, 3);
                break;
            case 2:
                eCount = 1;
                break;
        }

        for (int i = 0; i < eCount; i++)
        {
            enemyIdx = Random.Range(level + level * 3, 3 + level * 3);
            eData[i] = new Enemy_BattleData(eDict.enemyDatas[enemyIdx]);
        }
    }
    private void SkillSet()
    {
        for(int i = 0; i < 4; i++)
        {
            if(System_MainDataManager.mainData.skillUnlocked[i])
            {
                skillCoolTime[i] = sDict.skillDatas[i]._skillReadyTime;
                skillUsed[i] = false;
            }
        }
    }
    private void SkillCoolTimeControl()
    {
        for (int i = 0; i < 4; i++)
        {
            if (System_MainDataManager.mainData.skillUnlocked[i])
            {
                if(skillCoolTime[i] > 0)
                    skillCoolTime[i]--;
                else
                {
                    if(skillUsed[i])
                    {
                        skillCoolTime[i] = sDict.skillDatas[i]._skillCoolTime;
                        skillUsed[i] = false;
                    }
                }
            }
        }
    }
    private void PoolComponents()
    {
        sDict = GameObject.Find("SkillDictionary").GetComponent<System_SkillDictionary>();
        eDict = GameObject.Find("EnemyDictionary").GetComponent<System_EnemyDictionary>();
        act = GameObject.Find("BattleManager").GetComponent<Player_Action>();
        enemy_Act = GameObject.Find("BattleManager").GetComponent<Enemy_Action>();
    }
    private void Start()
    {
        UI_Manager.isBattle = true;
        System_MainDataManager.mainData.isBattleScene = true;
        enemySeed = System_MainDataManager.fieldEnemyData;
        enemyCount = 1;
        PoolComponents();
        eDict.EnemyGenerate();
        pData = new Player_BattleData(
             System_MainDataManager.mainData.maxHp,
             System_MainDataManager.mainData.curHp,
             System_MainDataManager.mainData.atkPoint,
             System_MainDataManager.mainData.defPoint
            );
        MakeEnemys(enemySeed, ref enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            eData[i].Set_AI();
        }
        for(int i = 0; i < 3; i++)
        {
            buffTimeAndCnt[i, 0] = 0;
            buffTimeAndCnt[i, 1] = 0;
        }
        targetEnemy = 0;
        turnCount = 1;
        SkillSet();
        RollDice();
    }
   
    void Update()
    {
        if(UI_Manager.isBattle)
        {
            //Debug.Log(pData._atkPoint);
            SelectTargetControl();
            PlayerAction();
            EnemyAction();
            if (pData._curHp <= 0)
                isPlayerDead = true;
            else
                isPlayerDead = false;
        }
        if(System_MainDataManager.mainData.isDebugMode)
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                pData._curHp = 0;
            }
            if(Input.GetKeyDown(KeyCode.F3))
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    if (eData[i].isAlive)
                        eData[i].isAlive = false;
                }
            }
        }
        
    }
    private void CameraSet()
    {
        cameraPos.x = 956.7f;
        cameraPos.y = 347.5f;
        cameraPos.z = -144.9f;

        cameraRot.eulerAngles = new Vector3(0, 15.6f, 0);

        battleCamera.transform.position = cameraPos;
        battleCamera.transform.rotation = cameraRot;
    }
    public void DoAttack(ref int enemyHp, int enemyDef, int myDamage)
    {
        if (myDamage <= enemyDef)
            return;

        enemyHp = enemyHp - (myDamage - enemyDef);
    }
    public void BasicAttack()                                   // 일반 공격
    {
        if (eData[targetEnemy].isAlive && enemy_Act.enemyAttackEnd)
        {
            act.isCalled = true;
            act.isBasicAttack = true;
        }
    }
    public void UseSkill(System_SkillData skillData)
    {
        skillNum = skillData._sIndex;
        switch(skillData._type)
        {
            case System_SkillData.SkillType._isAttack:
                SkillAttack(skillData._sIndex);
                break;
            case System_SkillData.SkillType._isBuff:
                UseBuffSkill(skillData._sIndex);
                break;
            case System_SkillData.SkillType._isDeBuff:
                break;
        }
    }
    public void SkillAttack(int idx)
    {
        if(skillCoolTime[idx] == 0)
        {
            if (eData[targetEnemy].isAlive && enemy_Act.enemyAttackEnd)
            {
                skillUsed[idx] = true;
                if (sDict.skillDatas[idx]._sHitCount < 2)
                {
                    act.isCalled = true;
                    if(idx == 3)
                    {
                        act.isAoESkill = true;
                    }
                    else
                    {
                        act.isSingleAttackSkill = true;
                    }
                }
                else
                {
                    act.isCalled = true;
                    act.isComboAttackSkill = true;
                }
            }
        }
    }
    public void UseBuffSkill(int idx)
    {
        if(skillCoolTime[idx] == 0)
        {
            if(enemy_Act.enemyAttackEnd)
            {
                skillUsed[idx] = true;
                act.isCalled = true;
                act.isBuffSkill = true;
            }
        }
    }
    public void CalBasicAttack()
    {
        int eHp = eData[targetEnemy]._targetHp;
        int eDef = eData[targetEnemy]._defPoint;
        DoAttack(ref eHp, eDef, pData._atkPoint);

        eData[targetEnemy]._targetHp = eHp;
        if (!eData[targetEnemy].isAlive)
        {
            isEnemyDead = true;
        }
        while (!eData[targetEnemy].isAlive && !IsCleared())
        {
            if (targetEnemy + 1 > enemyCount - 1) targetEnemy = 0;
            else targetEnemy++;
        }
        isCal = true;
    }
    public void CalAttackDamage(int sIndex, bool isAoE = false)     // 스킬 공격
    {
        if(!isAoE)
        {
            int eHp = eData[targetEnemy]._targetHp;
            int eDef = eData[targetEnemy]._defPoint;
            DoAttack(ref eHp, eDef, sDict.skillDatas[sIndex].CalculateSkillDamage(diceCount[0] + diceCount[1]));

            eData[targetEnemy]._targetHp = eHp;
            if (!eData[targetEnemy].isAlive)
            {
                isEnemyDead = true;
            }
            while (!eData[targetEnemy].isAlive && !IsCleared())
            {
                if (targetEnemy + 1 > enemyCount - 1) targetEnemy = 0;
                else targetEnemy++;
            }
        }
        else
        {
            for(int i = 0; i < enemyCount; i++)
            {
                int eHp = eData[i]._targetHp;
                int eDef = eData[i]._defPoint;
                DoAttack(ref eHp, eDef, sDict.skillDatas[sIndex].CalculateSkillDamage(diceCount[0] + diceCount[1]));

                eData[i]._targetHp = eHp;
                if (!eData[i].isAlive)
                {
                    isEnemyDead = true;
                }
            }
            while (!eData[targetEnemy].isAlive && !IsCleared())
            {
                if (targetEnemy + 1 > enemyCount - 1) targetEnemy = 0;
                else targetEnemy++;
            }
        }
        isCal = true;
    }
    public void CalBuff(int sIndex)
    {
        switch(sDict.skillDatas[sIndex]._bType)
        {
            case System_SkillData.BuffType._isHeal:
                BattleBuffs.Heal(ref pData._curHp, pData._maxHp, sDict.skillDatas[sIndex].CalculateSkillDamage(diceCount[0] + diceCount[1]));
                break;
        }
        isCal = true;
    }
    private void ApplyAttack()
    {
        if (act.isEffectPlayed && !isCal)
            CalBasicAttack();
    }
    private void ApplyAttack(int skillNum, bool isAoE = false)          // 스킬 공격 적용 선택 가능
    {
        if (act.isEffectPlayed && !isCal)
            CalAttackDamage(skillNum, isAoE);
    }
    private void ApplyBuff(int skillNum)
    {
        if (act.isEffectPlayed && !isCal)
            CalBuff(skillNum);
    }
    private void PlayerAction()                 // 플레이어 행동 관리
    {
        if (act.isCalled)                            // 플레이어 애니메이션
        {
            enemy_Act.enemyAttackEnd = false;
            if (act.isBasicAttack)
            {
                act.SoloAttack(targetEnemy, 0, 1.5f);
                ApplyAttack();
            }
            else if (act.isSingleAttackSkill)
            {
                act.SoloAttack(targetEnemy, skillNum + 1, 1.5f);
                ApplyAttack(skillNum, false);
            }
            else if (act.isComboAttackSkill)
            {
                act.ComboAttack(targetEnemy, skillNum + 1, sDict.skillDatas[skillNum]._sHitCount, 1.5f);
                ApplyAttack(skillNum);
            }
            else if(act.isBuffSkill)
            {
                act.BuffUse(skillNum + 1, 1.5f);
                ApplyBuff(skillNum);
            }
            else if(act.isAoESkill)
            {
                act.SoloAttack(targetEnemy, skillNum + 1, 1.5f, true);
                ApplyAttack(skillNum, true);
            }
        }
    }
    private void EnemyAction()          // 적 행동 관리
    {
        if (enemy_Act.isCalled && !IsCleared())      // 적 애니메이션
        {
            isEnemyAttack = true;
            if (!enemy_Act.enemyAttackEnd)
            {
                if (enemyAttackCheck())
                {
                    enemy_Act.enemyAttackEnd = true;
                    enemy_Act.isCalled = false;
                    turnCount++;
                }
                else
                {
                    if (!eData[enemyActionIndex].isAlive)        // 죽은 적 체크 후 인덱스 가장 빠른순으로 갱신
                    {
                        for (int i = 0; i < enemyCount; i++)
                        {
                            if (eData[i].isAlive && !eData[i]._isAttacked)
                            {
                                enemyActionIndex = i;
                                break;
                            }
                        }
                    }
                    //Debug.Log(enemyActionIndex);
                    if (eData[enemyActionIndex].isAlive && eData[enemyActionIndex]._enemyAI == Enemy_BattleData.EnemyAI.Attack)
                    {
                        
                        enemy_Act.AttackPlayer(enemyActionIndex, sysActionSpeed);
                        if (enemy_Act.isEffectPlayed && !enemyActed && enemyActionIndex < enemyCount)
                        {
                            EnemyAffect(enemyActionIndex);
                        }
                    }
                }
            }
        }
    }
    private bool enemyAttackCheck()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            if (eData[i].isAlive && !eData[i]._isAttacked)
                return false;
        }
        return true;
    }
    private void SelectTargetControl()
    {
        if (enemyCount > 1 && !IsCleared())
        {
            bool isSelected = false;
            if (Input.GetKeyDown(KeyCode.A))
            {
                while (!isSelected)  // 사망한 적 타겟팅 안되게 제어
                {
                    if (targetEnemy - 1 < 0) targetEnemy = enemyCount - 1;
                    else targetEnemy--;

                    if (eData[targetEnemy].isAlive) isSelected = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                while (!isSelected)  // 위와 기능 동일
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
        for (int i = 0; i < 2; i++)
        {
            diceCount[i] = Random.Range(1, 7);
        }
        isEnemyAttack = false;
        sDict.thisDiceCount = diceCount[0] + diceCount[1];
    }
    private void SetEnemyActionIndex(int enemyNum)
    {
        bool enemySelected = false;
        for (int i = 0; i < enemyNum; i++)
        {
            if (eData[i].isAlive)
            {
                if (!enemySelected)
                {
                    enemyActionIndex = i;
                    enemySelected = true;
                    break;
                }
            }
        }
        for(int i = 0; i < enemyNum; i++)
        {
            if (eData[i].isAlive)
                eData[i]._isAttacked = false;
        }
    }
    public void EnemyAffect(int enemyIndex)
    {
        eData[enemyIndex].Active_AI(ref pData._curHp);
        eData[enemyIndex].Set_AI();
        enemyActed = true;
    }
    public bool IsCleared()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if (eData[i].isAlive)
                return false;
        }
        return true;
    }
    public int RewardMoney()
    {
        int money = 0;
        for (int i = 0; i < enemyCount; i++)
        {
           money += eData[i]._money;
        }
        return money;
    }
    public void BattleReward()
    {
        uis.addItem();
        System_MainDataManager.mainData.playerMoney += RewardMoney();
    }
}