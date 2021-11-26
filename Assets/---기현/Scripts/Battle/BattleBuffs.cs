using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBuffs
{
    public static void Heal(ref int targetHp, int targetMaxHp, int healAmount)
    {
        if(targetHp + healAmount >= targetMaxHp)
        {
            targetHp = targetMaxHp;
        }
        else
        {
            targetHp += healAmount;
        }
    }
    public static void StatusBuff(ref int targetStatus, int buffAmount)
    {

    }
}
