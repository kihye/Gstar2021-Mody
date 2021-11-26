using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BattleData : BasicStatus
{
    public Player_BattleData()
    {
        _maxHp = 200;
        _atkPoint = 100;
        _defPoint = 10;

        _curHp = _maxHp;
    }
    public Player_BattleData(int maxHp, int curHp, int atkPoint, int defPoint)
    {
        _maxHp = maxHp;
        _curHp = curHp;
        _atkPoint = atkPoint;
        _defPoint = defPoint;
    }
}
