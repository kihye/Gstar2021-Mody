using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Action : BattlerAction
{
    public System_BattleManager bm;

    private Enemy_Action enemy_Act;

    public GameObject camGo;
    
    public Vector3 camPos;
    private Vector3 enemyPosCal;
    private Vector3 camPosCal;

    public bool isBasicAttack = false;
    public bool isSingleAttackSkill = false;
    public bool isComboAttackSkill = false;
    public bool isBuffSkill = false;
    public bool isAoESkill = false;

    private int comboCount;
    private void Awake()
    {
        aud = GameObject.Find("AudioStash").GetComponent<System_AudioStash>();
        enemy_Act = GameObject.Find("BattleManager").GetComponent<Enemy_Action>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializeEffects();
        InitializeDatas();

        aud.SoundsInitialize(true);

        ActionAdjust();

        camPos = camGo.transform.position;
    }
    public void ResetActionCheck()
    {
        isBasicAttack = false;
        isSingleAttackSkill = false;
        isComboAttackSkill = false;
        isBuffSkill = false;
        isAoESkill = false;
    }
    private void ActionAdjust()     // 카메라 및 플레이어 이동범위 제어
    {
        enemyPosCal.x = -1;
        enemyPosCal.y = 0;
        enemyPosCal.z = 0;

        camPosCal.x = 0;
        camPosCal.y = 3;
        camPosCal.z = -4;
    }
    private void PlayerMoveToEnemy(bool isFoward, int targetEnemy, float actionSpeed) // isFoward == true : 대상으로 이동, false : 원 위치로 이동
    {
        if(isFoward)
        {
            playerGo.transform.position = Vector3.Lerp(playerGo.transform.position, enemyGo[targetEnemy].transform.position + enemyPosCal, 0.03f * actionSpeed);
            camGo.transform.position = Vector3.Lerp(camGo.transform.position, playerGo.transform.position + camPosCal, 0.01f * actionSpeed);
        }
        else
        {
            playerGo.transform.position = Vector3.Lerp(playerGo.transform.position, playerPos, 0.02f * actionSpeed);
            camGo.transform.position = Vector3.Lerp(camGo.transform.position, camPos, 0.02f * actionSpeed);
        }
    }
    private void ResetControl()
    {
        isCalled = false;
        isEffectPlayed = false;
        timeStamp = 0;
        manager.isCal = false;
        manager.isEnemyDead = false;
        enemy_Act.isCalled = true;
    }
    private void AudioControl(int skillNum, bool isAttack)
    {
        if(isAttack)
            camGo.transform.position = camPos;

        if (skillNum == 0)
            aud.SoundStop(true, 0);
        else
            aud.SoundStop(true, skillNum);

        ResetControl();
    }
    public void BuffUse(int skillNum, float actionSpeed = 1f)
    {
        if (timeStamp >= ActionTime(1.2f, actionSpeed))
        {
            effects[skillNum].Stop();
            AudioControl(skillNum, true);
        }
        else
        {
            timeStamp += Time.deltaTime;
            EffectAndSoundControl(true, skillNum);
        }
    }
    public void SoloAttack(int targetEnemy, int skillNum, float actionSpeed = 1f, bool isAoE = false)       // 0 == 스킬 없음, 그 이외는 스킬 인덱스
    {
        float controlTime = 0f;
        if (skillNum == 0)
            controlTime = -0.4f;

        if(timeStamp >= ActionTime(3.6f + controlTime, actionSpeed))
        {
            AudioControl(skillNum, true);
        }
        else
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= ActionTime(2.2f + controlTime, actionSpeed) || manager.isEnemyDead)
            {
                effects[skillNum].Stop();
                PlayerMoveToEnemy(false, targetEnemy, actionSpeed);
            }
            else
            {
                if (timeStamp >= ActionTime(1.5f, actionSpeed))
                {
                    if (skillNum == 0)
                        EffectAndSoundControl(true, 0);
                    else
                        EffectAndSoundControl(true, skillNum);
                    if(isAoE)
                    {
                        for(int i = 0; i < bm.enemyCount; i++)
                        {
                            enemy_Act.EnemyKnockBack(i);
                        }
                    }
                    else
                    {
                        enemy_Act.EnemyKnockBack(targetEnemy);
                    }
                    System_CameraAct.instance.ShakeCam(true);
                }
                PlayerMoveToEnemy(true, targetEnemy, actionSpeed);
            }
        } 
    }
    public void ComboAttack(int targetEnemy, int skillNum, int attackCount, float actionSpeed = 1f)       // 0 == 스킬 없음, 그 이외는 스킬 인덱스
    {
        int tempNum = skillNum;
        if (timeStamp == 0)
        {
            comboCount = 0;
        }
        if (timeStamp >= ActionTime(3.6f, actionSpeed))
        {
            AudioControl(tempNum, true);
        }
        else
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= ActionTime(2.2f, actionSpeed) || manager.isEnemyDead)
            {
                effects[tempNum].Stop();
                PlayerMoveToEnemy(false, targetEnemy, actionSpeed);
            }
            else
            {
                float attackTime = 0.7f / (float)attackCount;
                if (timeStamp >= ActionTime(1.5f, actionSpeed) && comboCount < attackCount)
                {
                    if (timeStamp >= ActionTime(1.5f + attackTime, actionSpeed))
                    {
                        isEffectPlayed = false;
                        manager.isCal = false;
                        aud.SoundStop(true, tempNum);
                        comboCount++;
                        timeStamp = ActionTime(1.4f, actionSpeed);
                    }
                    else
                    {
                        if (tempNum == 0)
                            EffectAndSoundControl(true, 0);
                        else
                            EffectAndSoundControl(true, tempNum);
                        enemy_Act.EnemyKnockBack(targetEnemy);
                        System_CameraAct.instance.ShakeCam(true);
                    }
                }
                if (comboCount == attackCount)
                    timeStamp = ActionTime(2.2f, actionSpeed);
                PlayerMoveToEnemy(true, targetEnemy, actionSpeed);
            }
        }
    }
}
