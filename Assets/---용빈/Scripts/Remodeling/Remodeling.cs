using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remodeling : MonoBehaviour
{
    //private int lastFrameClicked = -1;
    //int thisFrame = Time.frameCount;

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

    public bool useW = true;

   public bool useRS = true;

  public  int useNewPocket = 3;

    public int _money = 1000000000;
    public int _atkPoint = 10;
    public int _defPoint = 10;

    public GameObject use;
    



    //private void Awake()
    //{
    //    _money = 1000000000;
    //}




    //----------------------------------안구--------------------------------------

    public void IQM() //정보 수치화 모듈(Information quantification module ) 의 약자
    {
        if (_money >= 1000000)
        {
            if (useIQM == true)
            {
                _money -= 1000000;
                useIQM = false;

               

            }
        }

    }

    public void EM() //탐색 모듈 ( Exploration module ) 의 약자
    {
        if (_money >= 1000000)
        {
            if (useEM == true)
            {
                _money -= 1000000;
                useEM = false;
            }
        }
    }

    public void HM() //해킹 모듈 ( Hacking module ) 의 약자
    {
        if (_money >= 1000000)
        {
            if (useHM == true)
            {
                _money -= 1000000;
                useHM = false;
            }
        }
    }

    //----------------------------------팔--------------------------------------

    //공격력
    public void IH() //외피 연마 ( integument hone ) 의 약자
    {
        
            if (useIH != 0)
            {
            if (_money >= 1000000)
            {
                _money = _money - 1000000;
            Debug.Log(_money);
            _atkPoint += 2;
                useIH = useIH - 1;
                Debug.Log(useIH);

            }
        }
    }

    public void MF() //근섬유( Muscle fiber ) 의 약자
    {
        if (_money >= 2000000)
        {
            if (useMF != 0)
            {
                _money -= 2000000;
                Debug.Log(_money);
                _atkPoint += 3;
                Debug.Log(_atkPoint);
                useMF -= 1;
                Debug.Log(useMF);
            }

        }
    }

    public void MM()//나노모터 (Nano motor) 의 약자
    {

            if (_money >= 4000000)
            {
                if (useMM != 0)
                {
                    _money -= 4000000;
                    _atkPoint += 5;
                    useMM -= 1;
                }
            }
        

    }

    public void PS() //파워 사이펀 ( Power Siphon ) 의 약자
    {
        if (_money >= 8000000)
        {
            if (usePS != 0)
            {
                _money -= 8000000;
                _atkPoint += 10;
                usePS -= 1;
            }
        }
    }


    //방어력
    public void QC() //담금질(quenching)
    {
        if (_money >= 1000000)
        {
            if (useQC != 0)
            {
                _money -= 1000000;
                _defPoint += 2;
                useQC -= 1;
            }
        }
    }

    public void HDE() //고밀도 외골격 (high density exoskeleton)의 약자
    {
        if (_money >= 2000000)
        {
            if (useHDE != 0)
            {
                _money -= 2000000;
                _defPoint += 3;
                useHDE -= 1;
            }
        }
    }

    public void TC() //티타늄 코팅 (titanium coating)의 약자
    {
        if (_money >= 4000000)
        {
            if (useTC != 0)
            {
                _money -= 4000000;
                _defPoint += 5;
                useHDE -= 1;
            }
        }
    }

    public void IHS() //순간 경질화 시스템 (instant hardening System)의 약자
    {
        if (_money >= 8000000)
        {
            if (useIHS != 0)
            {
                _money -= 8000000;
                _defPoint += 10;
                useIHS -= 1;
            }
        }
    }

    //무게
    public void LW() //경량화(lightweight)의 약자
    {
        if (_money >= 5000000)
        {
            if (useW)
            {
                _money -= 5000000;
                _atkPoint += 6;
                _defPoint -= 5;
                useW = false;
            }
        }
    }

    public void HW() //본래는 weight로 쓰는게 맞지만 헷갈리지 않게 Heavy를 붙임
    {
        if (_money >= 5000000)
        {
            if (useW)
            {
                _money -= 5000000;
                _atkPoint -= 5;
                _defPoint += 6;
                useW = false;
            }
        }
    }

    //----------------------------------다리--------------------------------------

    public void RS() //강화 골격 (reinforced skeleton)의 약자
    {
        if (_money >= 1000000)
        {
            if (useRS == true)
            {
                _money -= 1000000;
                useRS = false;
            }
        }
    }


    //----------------------------------주머니--------------------------------------

    public void NewPocket() //안감 덧대기(주머니 한줄 추가)
    {
        if (_money >= 1000000)
        {
            if (useNewPocket != 0)
            {
                _money -= 1000000;
                useNewPocket -= 1;
            }
        }
    }

}
