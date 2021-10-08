using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData
{
    public bool _isBuff;
    public bool _isDeBuff;
    public bool _isAttack;

    private int _sTargetDiceCount;   // 스킬이 요구하는 주사위 눈금

    public int _sIndex;             // 스킬 인덱스 번호
    public int _sDamage;           // 스킬 데미지
    public int _sHitCount;         // 데미지 스킬의 타격 회수

    private string _sName;
    private string _sInfo;
    public SkillData(int sIndex, int sTargetDiceCount, int sDamage, int sHitCount) // 기본 생성은 공격스킬로
    {
        _sIndex = sIndex;
        _sTargetDiceCount = sTargetDiceCount;
        _sDamage = sDamage;
        _sHitCount = sHitCount;
        _isAttack = true;
    }
    /*          
                주사위 갯수에 따른 스킬 효과 산출 방식
                주사위는 총 2개로, 2 ~ 12 까지의 숫자가 나올 수 있다.
                따라서 오차범위는 최대 ±10까지 계산할 수 있다.

                수치 환산은 다음에 따라 계산된다.
                
                ±0 : 기존 스킬의 100% 효과
                ±1 : 기존 스킬의 80% 효과
                ±2 : 기존 스킬의 75% 효과
                ±3 : 기존 스킬의 65% 효과
                ±4 : 기존 스킬의 55% 효과
                ±5 : 기존 스킬의 40% 효과
                ±6 : 기존 스킬의 25% 효과
                ±7 : 기존 스킬의 15% 효과
                ±8 : 기존 스킬의 10% 효과
                ±9 : 기존 스킬의 5% 효과
                ±10 : 기존 스킬의 1% 효과

                스킬 종류에 따른 적용법은 다음과 같다.
                1. 데미지는 퍼센티지만큼 감소시킨다.
                2. 버프 및 디버프는 효과가 적용 수치를 감소, 적용되는 턴 수는 감소시키지 않는다. 
    */
    private double CalculateEffectByDice(int diceCount)
    {
        double val;
        switch(diceCount)
        {
            case 0:     val = 1;
                break;
            case 1:     val = 0.8;
                break;
            case 2:     val = 0.75;
                break;
            case 3:     val = 0.65;
                break;
            case 4:     val = 0.55;
                break;
            case 5:     val = 0.4;
                break;
            case 6:     val = 0.25;
                break;
            case 7:     val = 0.15;
                break;
            case 8:     val = 0.1;
                break;
            case 9:     val = 0.05;
                break;
            case 10:    val = 0.01;
                break;
            default:
                val = 0;
                break;
        }
        return val;
    }
    public int CalculateSkillDamage(int myDiceCount)
    {
        double value = (double)_sDamage;
        value *= CalculateEffectByDice(Mathf.Abs(_sTargetDiceCount - myDiceCount));
        return (int)value;
    }
    public string sName
    {
        get { return _sName; }
        set { _sName = value; }
    }
    public string sInfo
    {
        get { return _sInfo; }
        set { _sInfo = value; }
    }
    public int TargetDiceCount()
    {
        return _sTargetDiceCount;
    }
}
