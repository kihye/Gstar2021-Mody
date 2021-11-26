using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_SkillDictionary : MonoBehaviour
{
    public System_SkillData[] skillDatas = new System_SkillData[4];
    public int thisDiceCount = 0;
    private void Awake()
    {
        skillDatas[0] = new System_SkillData(0, 6, System_MainDataManager.mainData.atkPoint, 1, 1, 2, System_SkillData.SkillType._isAttack);
        skillDatas[0].sName = "강타";
        skillDatas[0].sInfo = SkillnameAndDiceCount(skillDatas[0].sName, skillDatas[0].TargetDiceCount()) 
                                                + "\n적 한 개체에게 " + skillDatas[0]._sDamage + 
                                                    "\n( 현재 데미지 : " + skillDatas[0].CalculateSkillDamage(thisDiceCount) + " )" 
                                                        + "의 데미지를 입힙니다.";

        skillDatas[1] = new System_SkillData(1, 8, System_MainDataManager.mainData.atkPoint, 2, 2, 3, System_SkillData.SkillType._isAttack);
        skillDatas[1].sName = "연속 공격";
        skillDatas[1].sInfo = SkillnameAndDiceCount(skillDatas[1].sName, skillDatas[1].TargetDiceCount()) 
                                                +  "\n적 한 개체에게 " + skillDatas[1]._sDamage +
                                                    "\n( 현재 데미지 : " + skillDatas[1].CalculateSkillDamage(thisDiceCount) + " )" 
                                                        + "의 데미지를 " + skillDatas[1]._sHitCount + "회 입힙니다.";

        skillDatas[2] = new System_SkillData(2, 10, System_MainDataManager.mainData.atkPoint, 1, 3, 4, System_SkillData.SkillType._isBuff);
        skillDatas[2].sName = "긴급 수리";
        skillDatas[2].sInfo = SkillnameAndDiceCount(skillDatas[2].sName, skillDatas[2].TargetDiceCount())
                                                + "\n플레이어의 체력을 " + skillDatas[2]._sDamage +
                                                    "\n( 현재 회복량 : " + skillDatas[2].CalculateSkillDamage(thisDiceCount) + " )"
                                                        + "만큼 " + skillDatas[2]._sHitCount + "회 회복합니다.";

        skillDatas[3] = new System_SkillData(3, 12, System_MainDataManager.mainData.atkPoint, 1, 1, 4, System_SkillData.SkillType._isAttack);
        skillDatas[3].sName = "플라즈마 웨이브";
        skillDatas[3].sInfo = SkillnameAndDiceCount(skillDatas[3].sName, skillDatas[3].TargetDiceCount())
                                                + "\n모든 적 한 개체에게 " + skillDatas[3]._sDamage +
                                                    "\n( 현재 데미지 : " + skillDatas[3].CalculateSkillDamage(thisDiceCount) + " )"
                                                        + "의 데미지를 입힙니다.";

    }
    private void Update()
    {
        skillDatas[0].sInfo = SkillnameAndDiceCount(skillDatas[0].sName, skillDatas[0].TargetDiceCount())
                                                + "\n적 한 개체에게 " + skillDatas[0]._sDamage +
                                                    "( 현재 데미지 : " + skillDatas[0].CalculateSkillDamage(thisDiceCount) + " )"
                                                        + "의 데미지를 입힙니다.";

        skillDatas[1].sInfo = SkillnameAndDiceCount(skillDatas[1].sName, skillDatas[1].TargetDiceCount())
                                                + "\n적 한 개체에게 " + skillDatas[1]._sDamage +
                                                    "( 현재 데미지 : " + skillDatas[1].CalculateSkillDamage(thisDiceCount) + " )"
                                                        + "의 데미지를 " + skillDatas[1]._sHitCount + "회 입힙니다.";

        skillDatas[2].sInfo = SkillnameAndDiceCount(skillDatas[2].sName, skillDatas[2].TargetDiceCount())
                                                + "\n플레이어의 체력을 " + skillDatas[2]._sDamage +
                                                    "\n( 현재 회복량 : " + skillDatas[2].CalculateSkillDamage(thisDiceCount) + " )"
                                                        + "만큼 " + skillDatas[2]._sHitCount + "회 회복합니다.";

        skillDatas[3].sInfo = SkillnameAndDiceCount(skillDatas[3].sName, skillDatas[3].TargetDiceCount())
                                                + "\n모든 적 한 개체에게 " + skillDatas[3]._sDamage +
                                                    "\n( 현재 데미지 : " + skillDatas[3].CalculateSkillDamage(thisDiceCount) + " )"
                                                        + "의 데미지를 입힙니다.";
    }
    private string SkillnameAndDiceCount(string skillName, int diceCount)
    {
        return "[" + skillName + " | 요구 눈금 " + diceCount + "]";
    }
}
