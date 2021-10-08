using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;         //사운드 이름
    public AudioClip clip;      //사운드 파일
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioMixer mixer;

    public AudioSource[] audioSourceSFX;    //현재 재생 중인 이펙트 사운드
    public AudioSource audioSourceBGM;      //현재 재생 중인 배경 사운드

    public Sound[] sfx;                     //전체 이펙트 사운드
    public Sound[] bgm;                     //전체 배경 사운드

    public string[] playingSFXName;         //현재 재생 중인 이펙트 사운드의 이름

    //SoundManager : singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }

        PlayBGM("B1");
    }

    void Start()
    {
        playingSFXName = new string[audioSourceSFX.Length];
    }

    //
    //이펙트 사운드
    public void PlaySFX(string _name)       //이펙트 사운드 재생
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (_name == sfx[i].name)       //재생하려는 사운드가 이펙트 사운드 모음에 존재한다면
            {
                for (int j = 0; j < audioSourceSFX.Length; j++)
                {
                    if (!audioSourceSFX[j].isPlaying)
                    {
                        playingSFXName[j] = sfx[i].name;
                        audioSourceSFX[j].clip = sfx[i].clip;
                        audioSourceSFX[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 AudioSource가 사용 중입니다.");
                return;
            }
        }
        Debug.Log(_name + "사운드는 SoundManager에 등록되지 않았습니다.");
    }

    public void AllStopSFX()                //재생 중인 모든 이펙트 사운드 재생 종료
    { 
        for (int i = 0; i < audioSourceSFX.Length; i++)
        {
            audioSourceSFX[i].Stop();
        }
    }

    public void StopSFX(string _name)       //재생 중인 사운드 중 특정 이펙트 사운드 재생 종료
    {
        for (int i = 0; i < audioSourceSFX.Length; i++)
        {
            if (playingSFXName[i] == _name)
            {
                audioSourceSFX[i].Stop();
                return;
            }
        }
        Debug.Log("이펙트 사운드 " + _name +"는 현재 재생 중이 아닙니다.");
    }

    //
    //배경 사운드
    public void PlayBGM(string _name)       //배경 사운드 재생
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (_name == bgm[i].name)       //재생하려는 사운드가 배경 사운드 모음에 존재한다면
            {
                audioSourceBGM.clip = bgm[i].clip;
                audioSourceBGM.Play();
                return;
            }
        }
        Debug.Log(_name + "사운드는 SoundManager에 등록되지 않았습니다.");
    }

    public void StopBGM()                   //재생 중인 배경 사운드 종료
    {
        audioSourceBGM.Stop();
    }
}
