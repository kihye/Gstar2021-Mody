using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : BasicStatus
{
    public enum EnemyLevel { Low, Middle, High};
    public enum EnemyType { Offense, Balance, Defense};
    public EnemyLevel _eLevel;
    public EnemyType _eType;

    public int _rewardMoney;
    public string _name;
    public EnemyData()
    {
        _rewardMoney = 500000;      // 500,000
        _atkPoint = 10;
        _defPoint = 10;
        _maxHp = 150;
        _name = "LW-";
    }
    public void MakeEnemy(EnemyLevel eLevel, EnemyType eType)
    {
        switch(eLevel)
        {
            case EnemyLevel.Low:
                _rewardMoney = 500000;      // 500,000
                _atkPoint = 10;
                _defPoint = 10;
                _maxHp = 150;
                _name = "LW-";
                break;
            case EnemyLevel.Middle:
                _rewardMoney = 1000000;    // 1,000,000
                _atkPoint = 30;
                _defPoint = 30;
                _maxHp = 300;
                _name = "MD-";
                break;
            case EnemyLevel.High:
                _rewardMoney = 3000000;    // 3,000,000
                _atkPoint = 60;
                _defPoint = 60;
                _maxHp = 600;
                _name = "HG-";
                break;
        }
        MakeEnemyData(eType);
    }
    private void MakeEnemyData(EnemyType eType)
    {
        switch(eType)
        {
            case EnemyType.Offense:
                _rewardMoney += (_rewardMoney / 2);

                _atkPoint += (int)(_atkPoint * 0.2);
                _defPoint -= (int)(_defPoint * 0.2);
                _name += "A";
                break;
            case EnemyType.Balance:
                _name += "B";
                break;
            case EnemyType.Defense:
                _rewardMoney += (_rewardMoney / 2);

                _atkPoint -= (int)(_atkPoint * 0.2);
                _defPoint += (int)(_defPoint * 0.2);
                _name += "C";
                break;
        }
    }
}
