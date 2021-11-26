using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_AudioStash : MonoBehaviour
{
    public AudioSource[] pEffectSounds;
    // 0 == 기본 타격

    public AudioSource[] eEffectSounds;
    // 0 == 플레이어 피격음

    public void SoundsInitialize(bool isPlayer)     // isPlayer == 플레이어 관련 사운드면 true, 아니면 false
    {
        if(isPlayer)
        {
            for (int i = 0; i < pEffectSounds.Length; i++)
            {
                pEffectSounds[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < eEffectSounds.Length; i++)
            {
                eEffectSounds[i].gameObject.SetActive(false);
            }
        }
    }
    public void SoundPlay(bool isPlayer, int index)     
    {
        if(isPlayer)
        {
            if (!pEffectSounds[index].gameObject.activeSelf)
                pEffectSounds[index].gameObject.SetActive(true);
            else
            {
                pEffectSounds[index].Play();
            }
        }
        else
        {
            if (!eEffectSounds[index].gameObject.activeSelf)
                eEffectSounds[index].gameObject.SetActive(true);
            else
            {
                eEffectSounds[index].Play();
            }
        }
    }
    public void SoundStop(bool isPlayer, int index)
    {
        if (isPlayer)
            pEffectSounds[index].Stop();
        else
            eEffectSounds[index].Stop();
    }
}
