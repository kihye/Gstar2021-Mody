using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remodeling : Stat
{
    public bool useIQM = true;
    public bool useEM = true;
    public bool useHM = true;


    public int useIH = 2;
    public int useMF = 2;
    public int useMM = 3;
    public int usePS = 3;

    public int useQC = 2;
    public int useHDE = 2;
    public int useTC = 3;
    public int useIHS = 3;

    public bool useW;


    bool useRS = true;

    int useNewPocket = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //----------------------------------안구--------------------------------------

    public void IQM() //정보 수치화 모듈(Information quantification module ) 의 약자
    {
        if (useIQM == true)
        {
            _money -= 1000000;
            useIQM = false;

            Debug.Log(_money);
            Debug.Log(useIQM);
        }
        

    }

    public void EM() //탐색 모듈 ( Exploration module ) 의 약자
    {
        if (useEM == true)
        {
            _money -= 1000000;
            useEM = false;
        }
    }

    public void HM() //해킹 모듈 ( Hacking module ) 의 약자
    {
        if (useHM == true)
        {
            _money -= 1000000;
            useHM = false;
        }
    }

    //----------------------------------팔--------------------------------------

    //공격력
    public void IH() //외피 연마 ( integument hone ) 의 약자
    {
        if (useIH != 0)
        {
            _money -= 1000000;
            _atk += 2;
            useIH -= 1;
        }
    }

    public void MF() //근섬유( Muscle fiber ) 의 약자
    {
        if (useMF != 0)
        {
            _money -= 2000000;
            _atk += 3;
            useMF -= 1;
        }
    }

    public void MM()//나노모터 (Nano motor) 의 약자
    {
        if (useMM != 0)
        {
            _money -= 4000000;
            _atk += 5;
            useMM -= 1;
        }
    }

    public void PS() //파워 사이펀 ( Power Siphon ) 의 약자
    {
        if (usePS != 0)
        {
            _money -= 8000000;
            _atk += 10;
            usePS -= 1;
        }
    }


    //방어력
    public void QC() //담금질(quenching)
    {
        if (useQC != 0)
        {
            _money -= 1000000;
            _def += 2;
            useQC -= 1;
        }
    }

    public void HDE() //고밀도 외골격 (high density exoskeleton)의 약자
    {
        if (useHDE != 0)
        {
            _money -= 2000000;
            _def += 3;
            useHDE -= 1;
        }
    }

    public void TC() //티타늄 코팅 (titanium coating)의 약자
    {
        if (useTC != 0)
        {
            _money -= 4000000;
            _def += 5;
            useHDE -= 1;
        }
    }

    public void IHS() //순간 경질화 시스템 (instant hardening System)의 약자
    {
        if (useIHS != 0)
        {
            _money -= 8000000;
            _def += 10;
            useIHS -= 1;
        }
    }

    //무게
    public void LW() //경량화(lightweight)의 약자
    {
        if (useW)
        {
            _money -= 5000000;
            _atk += 6;
            _def -= 5;
            useW = false;
        }
    }

    public void HW() //본래는 weight로 쓰는게 맞지만 헷갈리지 않게 Heavy를 붙임
    {
        if (useW)
        {
            _money -= 5000000;
            _atk -= 5;
            _def += 6;
            useW = false;
        }
    }

    //----------------------------------다리--------------------------------------

    public void RS() //강화 골격 (reinforced skeleton)의 약자
    {
        if (useRS == true)
        {
            _money -= 1000000;
            useRS = false;
        }
    }


    //----------------------------------주머니--------------------------------------

    public void NewPocket() //안감 덧대기(주머니 한줄 추가)
    {
        if (useNewPocket != 0)
        {
            _money -= 1000000;
            useNewPocket -= 1;
        }
    }

}
