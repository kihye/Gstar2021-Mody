using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BattleData : BasicStatus
{
    private int _eTurn;

    public bool isAlive = false;

    public enum EnemyAI { Attack, Defense, Buff, Debuff }
    public EnemyAI _enemyAI;
    public string _enemyName;
    public int _money;

    public bool _isAttacked;

    public Enemy_BattleData()
    {
        isAlive = true;
        _maxHp = 20;
        _atkPoint = 5;
        _defPoint = 1;
        _eTurn = 0;

        _curHp = _maxHp;
    }
    public Enemy_BattleData(EnemyData enemyData)
    {
        isAlive = true;
        _isAttacked = false;
        _maxHp = enemyData._maxHp;
        _atkPoint = enemyData._atkPoint;
        _defPoint = enemyData._defPoint;
        _enemyName = enemyData._name;
        _money = enemyData._rewardMoney;
        _eTurn = 0;
        _curHp = _maxHp;
        
    }
    public int _targetHp
    {
        get { return _curHp; }
        set
        {
            _curHp = value;
            if (value <= 0) isAlive = false;    // 체력 0일시 프로퍼티를 통한 사망처리
        }
    }
    public void Set_AI()
    {
        _eTurn++;
        _enemyAI = EnemyAI.Attack;
    }
    public void Active_AI(ref int playerHp)
    {
        switch(_enemyAI)
        {
            case EnemyAI.Attack:
                if(_eTurn >= 1)
                {
                    Attack_AI(ref playerHp);
                }
                break;
        }
    }
    public void Attack_AI(ref int playerHp)
    {
        if (playerHp - _atkPoint <= 0)
            playerHp = 0;
        else
            playerHp = playerHp - _atkPoint;
    }
}
