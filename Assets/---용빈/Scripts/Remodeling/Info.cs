using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Info : Remodeling
{
    public Image image;
    public Text nametext;
    public Text infotext;
    public Button rebutton;
    public Text btntext;
    public Text price;
    string btnName;

    //Sprite[] sprites = Resources.LoadAll<Sprite>("");

    string temp;

    public GameObject gameObject;

    internal static object intance;

    public void ClickBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        btnName = clickObject.name;
    }

    public void Use()
    {
        switch (btnName)
        {
            //===========안구==========//
            case "Module1":
                rebutton.onClick.AddListener(() => IQM(ref System_MainDataManager.mainData.playerMoney));
                nametext.text = "정보 수치화 모듈";
                infotext.text = "전투 시 적의 다음 행동을 수치화하여 볼 수 있다.";
                //image = Resources.Load("T_1_eye_.") as Image;
                temp = btnName;
                rebutton.name = temp;
                temp = null;
                price.text = "1000000";

                break;

            case "Module2":
                temp = btnName;
                rebutton.name = temp;
                temp = null;
                nametext.text = "탐색 모듈";
                infotext.text = "적의 상세한 스테이터스를 볼 수 있다.";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;

                price.text = "1000000";
                rebutton.onClick.AddListener(() => EM(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module3":
                temp = btnName;
                rebutton.name = temp;
                temp = null;
                nametext.text = "해킹 모듈";
                infotext.text = "전투에서 승리할 경우, 적의 시체에서 더 많은 현금을 찾아낸다.";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;

                price.text = "1000000";
                rebutton.onClick.AddListener(() => HM(ref System_MainDataManager.mainData.playerMoney));
                break;

            //===========팔==========//

            //-------------공격력-------------//
            case "Module4":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "외피 연마";
                infotext.text = "공격력 + 2";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "1000000";
                rebutton.onClick.AddListener(() => IH(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module5":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "근섬유 수축기";
                infotext.text = "공격력 + 3";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "2000000";
                rebutton.onClick.AddListener(() => MF(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module6":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "나노 모터";
                infotext.text = "공격력 + 5";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "4000000";
                rebutton.onClick.AddListener(() => MM(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module7":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "파워 사이펀";
                infotext.text = "공격력 + 10";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "8000000";
                rebutton.onClick.AddListener(() => PS(ref System_MainDataManager.mainData.playerMoney));

                break;
            //-------------방어력-------------//
            case "Module8":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "담금질";
                infotext.text = "방어력 + 2";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "1000000";
                rebutton.onClick.AddListener(() => QC(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module9":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "고밀도 외골격";
                infotext.text = "방어력 + 3";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "2000000";
                rebutton.onClick.AddListener(() => HDE(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module10":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "티타늄 코팅";
                infotext.text = "방어력 + 5";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "4000000";
                rebutton.onClick.AddListener(() => TC(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module11":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "순간 경질화 시스템";
                infotext.text = "방어력 + 10";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "8000000";
                rebutton.onClick.AddListener(() => IHS(ref System_MainDataManager.mainData.playerMoney));

                break;

            //-------------무게-------------//

            case "Module12":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "중량화";
                infotext.text = "공격력 - 5, 방어력 + 6";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "5000000";
                rebutton.onClick.AddListener(() => HW(ref System_MainDataManager.mainData.playerMoney));

                break;

            case "Module13":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "경량화";
                infotext.text = "방어력 - 5, 공격력 + 6";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "5000000";
                rebutton.onClick.AddListener(() => LW(ref System_MainDataManager.mainData.playerMoney));

                break;

            //===========다리==========//

            case "Module14":

                temp = btnName;
                rebutton.name = temp;
                nametext.text = "강화 골격";
                infotext.text = "이동 수치 보정 + 1";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "1000000";
                rebutton.onClick.AddListener(() => RS(ref System_MainDataManager.mainData.playerMoney));
                break;


            //===========주머니==========//

            case "Module15":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "인감 덧대기";
                infotext.text = "주머니 속 한 줄을 해금한다.";
                //image.sprite = Resources.Load("T_1_eye_.png") as Sprite;
                price.text = "1000000";
                rebutton.onClick.AddListener(() => NewPocket(ref System_MainDataManager.mainData.playerMoney));

                break;
        }
    }

    public void u()
    {
        gameObject.SetActive(false);
        Debug.Log(gameObject.activeSelf);
        gameObject.SetActive(true);
        Debug.Log(gameObject.activeSelf);
    }

    void Update()
    {
        if(btnName == "Module1")
        {
            if (RemodelShopData.instance.iqm == true)
            {
                btntext.text = "개조하기( 1 / 1 )";
            }
            else if (RemodelShopData.instance.iqm == false) { btntext.text = "개조하기( 0 / 1 )";}
        }

        else if(btnName == "Module2")
        {
            if (RemodelShopData.instance.em == true)
            {
                btntext.text = "개조하기( 1 / 1 )";
            }
            else if (RemodelShopData.instance.em == false) { btntext.text = "개조하기( 0 / 1 )";}
        }

        else if(btnName == "Module3")
        {
            if (RemodelShopData.instance.hm == true)
            {
                btntext.text = "개조하기( 1 / 1 )";
            }
            else if (RemodelShopData.instance.hm == false) { btntext.text = "개조하기( 0 / 1 )";}
        }

        else if(btnName == "Module4")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.ih + " / 2 )";
        }

        else if (btnName == "Module5")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.mf + " / 2 )";
        }

        else if (btnName == "Module6")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.mm + " / 3 )";
        }

        else if (btnName == "Module7")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.ps + " / 3 )";
        }

        else if (btnName == "Module8")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.qc + " / 2 )";
        }

        else if (btnName == "Module9")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.hde + " / 2 )";
        }

        else if (btnName == "Module10")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.tc + " / 3 )";
        }

        else if (btnName == "Module11")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.ihs + " / 3 )";
        }

        else if (btnName == "Module12")
        {
            if (RemodelShopData.instance.w) { btntext.text = "개조하기( 1 / 1 )"; }
            else { btntext.text = "개조하기( 0 / 1 )"; }
        }

        else if (btnName == "Module13")
        {
            if (RemodelShopData.instance.w) { btntext.text = "개조하기( 1 / 1 )"; }
            else { btntext.text = "개조하기( 0 / 1 )"; }
        }

        else if (btnName == "Module14")
        {
            if (RemodelShopData.instance.rs) { btntext.text = "개조하기( 1 / 1 )"; }
            else { btntext.text = "개조하기( 0 / 1 )"; }
        }

        else if (btnName == "Module15")
        {
            btntext.text = "개조하기( " + RemodelShopData.instance.newPocket + " / 3 )";
        }

    }
}

