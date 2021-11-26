using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerAction : MonoBehaviour
{
    public GameObject playerGo;
    public GameObject[] enemyGo = new GameObject[4];

    public ParticleSystem[] effects;

    public Vector3 playerPos;

    public bool isEffectPlayed = false;
    public bool isCalled = false;

    protected System_BattleManager manager;
    protected System_AudioStash aud;

    protected float timeStamp = 0;
    protected float timeSet = 0;

    protected void InitializeEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].gameObject.SetActive(false);
        }
    }
    protected void InitializeDatas()
    {
        manager = GameObject.Find("BattleManager").GetComponent<System_BattleManager>();
        playerPos = playerGo.transform.position;
    }
    protected void EffectAndSoundControl(bool isPlayer, int index)
    {
        //Debug.Log(index);
        effects[index].gameObject.SetActive(true);
        if (!isEffectPlayed)
        {
            effects[index].Play();
            if (isPlayer)
                aud.SoundPlay(true, index);
            else
                aud.SoundPlay(false, index);
            isEffectPlayed = true;
        }
    }
    protected float ActionTime(float checkTime, float speedMultply)
    {
        return checkTime / speedMultply;
    }
    protected void EffectStop(int index)
    {
        effects[index].Stop();
    }
}
