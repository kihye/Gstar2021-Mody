using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Action : BattlerAction
{
    public bool enemyAttackStart = false;
    public bool enemyAttackEnd = true;

    [SerializeField]
    private Vector3[] enemyPos = new Vector3[4]; // 적 원래 위치
    private Vector3 adjustPos;

    private void Awake()
    {
        aud = GameObject.Find("AudioStash").GetComponent<System_AudioStash>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        InitializeEffects();
        InitializeDatas();

        aud.SoundsInitialize(false);
        
        ActionAdjust();
        enemyAttackEnd = true;
        for(int i = 0; i < 4; i++)
        {
            enemyPos[i] = enemyGo[i].transform.position;
        }
    }
    private void ActionAdjust()
    {
        adjustPos.x = 1.2f;
        adjustPos.y = 0;
        adjustPos.z = 0;
    }
    public void EnemyMoveToPlayer(bool isFoward, int enemyIndex, float actionSpeed) // isFoward == true : 대상으로 이동, false : 원 위치로 이동
    {
        if (isFoward)
        {
            enemyGo[enemyIndex].transform.position = Vector3.Lerp(enemyGo[enemyIndex].transform.position, playerGo.transform.position + adjustPos, 0.03f * actionSpeed);
        }
        else
        {
            enemyGo[enemyIndex].transform.position = Vector3.Lerp(enemyGo[enemyIndex].transform.position, enemyPos[enemyIndex], 0.02f * actionSpeed);
        }
    }
    public void EnemyKnockBack(int enemyIndex)
    {
        Vector3 pos = enemyGo[enemyIndex].transform.position;
        pos.x += 2;
        enemyGo[enemyIndex].transform.position = Vector3.Lerp(enemyGo[enemyIndex].transform.position, pos, 0.02f);
    }
    public void AttackPlayer(int enemyIndex, float actionSpeed =1f)
    {
        if(timeStamp >= ActionTime(3.6f, actionSpeed))
        {
            manager.eData[enemyIndex]._isAttacked = true;
            timeStamp = 0;
            aud.SoundStop(false, 0);
            manager.enemyActed = false;
            manager.enemyActionIndex++;
            isEffectPlayed = false;
        }
        else
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= ActionTime(1.8f, actionSpeed))
            {
                EffectStop(0);
                EnemyMoveToPlayer(false, enemyIndex, actionSpeed);
            }
            else
            {
                if(timeStamp >= ActionTime(1.5f, actionSpeed))
                {
                    EffectAndSoundControl(false, 0);
                    System_CameraAct.instance.ShakeCam(false);
                }
                EnemyMoveToPlayer(true, enemyIndex, actionSpeed);
            }
        }
    }
}
