using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remodeling : MonoBehaviour
{
    //private int lastFrameClicked = -1;
    //int thisFrame = Time.frameCount;

    //public int _money = 1000000000;
    public int _atkPoint;
    public int _defPoint;

    public GameObject use;
    
    //----------------------------------안구--------------------------------------

    public void IQM(ref int _money) //정보 수치화 모듈(Information quantification module ) 의 약자
    {
        if (_money >= 1000000)
        {
            if (RemodelShopData.instance.iqm == true)
            {
                _money -= 1000000;
                System_MainDataManager.mainData.rm_IQM = true;
                RemodelShopData.instance.iqm = false;
            }
        }

    }

    public void EM(ref int _money) //탐색 모듈 ( Exploration module ) 의 약자
    {
        if (_money >= 1000000)
        {
            if (RemodelShopData.instance.em == true)
            {
                _money -= 1000000;
                RemodelShopData.instance.em = false;
            }
        }
    }

    public void HM(ref int _money) //해킹 모듈 ( Hacking module ) 의 약자
    {
        if (_money >= 1000000)
        {
            if (RemodelShopData.instance.hm == true)
            {
                _money -= 1000000;
                RemodelShopData.instance.hm = false;
            }
        }
    }

    //----------------------------------팔--------------------------------------

    //공격력
    public void IH(ref int _money) //외피 연마 ( integument hone ) 의 약자
    {
        
        if (RemodelShopData.instance.ih != 0)
        {
            if (_money >= 1000000)
            {
                _money = _money - 1000000;
                Debug.Log(_money);
                System_MainDataManager.mainData.atkPoint += 3;
                RemodelShopData.instance.ih = RemodelShopData.instance.ih - 1;
                Debug.Log(RemodelShopData.instance.ih);

            }
        }
    }

    public void MF(ref int _money) //근섬유( Muscle fiber ) 의 약자
    {
        if (_money >= 2000000)
        {
            if (RemodelShopData.instance.mf != 0)
            {
                _money -= 2000000;
                Debug.Log(_money);
                System_MainDataManager.mainData.atkPoint += 5;
                Debug.Log(_atkPoint);
                RemodelShopData.instance.mf -= 1;
                Debug.Log(RemodelShopData.instance.mf);
            }

        }
    }

    public void MM(ref int _money)//나노모터 (Nano motor) 의 약자
    {

            if (_money >= 4000000)
            {
                if (RemodelShopData.instance.mm != 0)
                {
                    _money -= 4000000;
                    System_MainDataManager.mainData.atkPoint += 10;
                RemodelShopData.instance.mm -= 1;
                }
            }
        

    }

    public void PS(ref int _money) //파워 사이펀 ( Power Siphon ) 의 약자
    {
        if (_money >= 8000000)
        {
            if (RemodelShopData.instance.ps != 0)
            {
                _money -= 8000000;
                System_MainDataManager.mainData.atkPoint += 15;
                RemodelShopData.instance.ps -= 1;
            }
        }
    }


    //방어력
    public void QC(ref int _money) //담금질(quenching)
    {
        if (_money >= 1000000)
        {
            if (RemodelShopData.instance.qc != 0)
            {
                _money -= 1000000;
                System_MainDataManager.mainData.defPoint += 2;
                RemodelShopData.instance.qc -= 1;
            }
        }
    }

    public void HDE(ref int _money) //고밀도 외골격 (high density exoskeleton)의 약자
    {
        if (_money >= 2000000)
        {
            if (RemodelShopData.instance.hde != 0)
            {
                _money -= 2000000;
                System_MainDataManager.mainData.defPoint += 3;
                RemodelShopData.instance.hde -= 1;
            }
        }
    }

    public void TC(ref int _money) //티타늄 코팅 (titanium coating)의 약자
    {
        if (_money >= 4000000)
        {
            if (RemodelShopData.instance.tc != 0)
            {
                _money -= 4000000;
                System_MainDataManager.mainData.defPoint += 5;
                RemodelShopData.instance.tc -= 1;
            }
        }
    }

    public void IHS(ref int _money) //순간 경질화 시스템 (instant hardening System)의 약자
    {
        if (_money >= 8000000)
        {
            if (RemodelShopData.instance.ihs != 0)
            {
                _money -= 8000000;
                System_MainDataManager.mainData.defPoint += 10;
                RemodelShopData.instance.ihs -= 1;
            }
        }
    }

    //무게
    public void LW(ref int _money) //경량화(lightweight)의 약자
    {
        if (_money >= 5000000)
        {
            if (RemodelShopData.instance.w)
            {
                _money -= 5000000;
                System_MainDataManager.mainData.atkPoint += 6;
                System_MainDataManager.mainData.defPoint -= 5;
                RemodelShopData.instance.w = false;
            }
        }
    }

    public void HW(ref int _money) //본래는 weight로 쓰는게 맞지만 헷갈리지 않게 Heavy를 붙임
    {
        if (_money >= 5000000)
        {
            if (RemodelShopData.instance.w)
            {
                _money -= 5000000;
                System_MainDataManager.mainData.atkPoint -= 5;
                System_MainDataManager.mainData.defPoint += 6;
                RemodelShopData.instance.w = false;
            }
        }
    }

    //----------------------------------다리--------------------------------------

    public void RS(ref int _money) //강화 골격 (reinforced skeleton)의 약자
    {
        if (_money >= 1000000)
        {
            if (RemodelShopData.instance.rs == true)
            {
                _money -= 1000000;
                RemodelShopData.instance.rs = false;
            }
        }
    }


    //----------------------------------주머니--------------------------------------

    public void NewPocket(ref int _money) //안감 덧대기(주머니 한줄 추가)
    {
        if (_money >= 1000000)
        {
            if (RemodelShopData.instance.newPocket != 0)
            {
                _money -= 1000000;
                RemodelShopData.instance.newPocket -= 1;
            }
        }
    }

}
