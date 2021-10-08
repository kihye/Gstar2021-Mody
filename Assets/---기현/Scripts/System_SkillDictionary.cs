using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_SkillDictionary : MonoBehaviour
{
    public SkillData[] skillDatas = new SkillData[2];
    public int thisDiceCount = 0;
    private void Awake()
    {
        skillDatas[0] = new SkillData(0, 6, 15, 1);
        skillDatas[0].sName = "강타";
        skillDatas[0].sInfo = SkillnameAndDiceCount(skillDatas[0].sName, skillDatas[0].TargetDiceCount()) 
                                                + "\n적 한 개체에게 " + skillDatas[0]._sDamage + 
                                                    "\n( 현재 데미지 : " + skillDatas[0].CalculateSkillDamage(thisDiceCount) + " )" 
                                                        + "의 데미지를 입힙니다.";

        skillDatas[1] = new SkillData(1, 8, 12, 2);
        skillDatas[1].sName = "연속 공격";
        skillDatas[1].sInfo = SkillnameAndDiceCount(skillDatas[1].sName, skillDatas[1].TargetDiceCount()) 
                                                +  "\n적 한 개체에게 " + skillDatas[1]._sDamage +
                                                    "\n( 현재 데미지 : " + skillDatas[1].CalculateSkillDamage(thisDiceCount) + " )" 
                                                        + "의 데미지를 " + skillDatas[1]._sHitCount + "회 입힙니다.";

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
    }
    private string SkillnameAndDiceCount(string skillName, int diceCount)
    {
        return "[" + skillName + " | 요구 눈금 " + diceCount + "]";
    }
}
