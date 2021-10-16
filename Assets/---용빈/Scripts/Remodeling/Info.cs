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
                rebutton.onClick.AddListener(IQM);
                nametext.text = "정보 수치화 모듈";
                infotext.text = "전투 시 적의 다음 행동을 수치화하여 볼 수 있다.";
                temp = btnName;
                rebutton.name = temp;
                temp = null;
                //if (useIQM == true)
                //{
                //    btntext.text = "개조하기( 1 / 1 )";
                //}
                //else if (useIQM == false) { btntext.text = "개조하기( 0 / 1 )"; Debug.Log(useIQM); }
                price.text = "1000000";
                Debug.Log("Module1");
                Debug.Log(_money);
                break;

            case "Module2":
                temp = btnName;
                rebutton.name = temp;
                temp = null;
                nametext.text = "탐색 모듈";
                infotext.text = "적의 상세한 스테이터스를 볼 수 있다.";
                //if (useEM == true)
                //{
                //    btntext.text = "개조하기( 1 / 1 )";
                //}
                //else if (useEM == false) { btntext.text = "개조하기( 0 / 1 )"; Debug.Log(useEM); }
                price.text = "1000000";
                Debug.Log("Module2");
                rebutton.onClick.AddListener(EM);

                break;

            case "Module3":
                temp = btnName;
                rebutton.name = temp;
                temp = null;
                nametext.text = "해킹 모듈";
                infotext.text = "전투에서 승리할 경우, 적의 시체에서 더 많은 현금을 찾아낸다.";
                //if (useHM == true)
                //{
                //    btntext.text = "개조하기( 1 / 1 )";
                //}
                //else if (useHM == false) { btntext.text = "개조하기( 0 / 1 )"; Debug.Log(useHM); }
                price.text = "1000000";
                Debug.Log("Module3");
                rebutton.onClick.AddListener(HM);
                break;

            //===========팔==========//

            //-------------공격력-------------//
            case "Module4":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "외피 연마";
                infotext.text = "공격력 + 2";
                //btntext.text = "개조하기( " + useIH + " / 2 )";
                price.text = "1000000";
                Debug.Log("Module4");
                rebutton.onClick.AddListener(IH);
                //Debug.Log(useIH);
                break;

            case "Module5":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "근섬유 수축기";
                infotext.text = "공격력 + 3";
                //btntext.text = "개조하기( " + useMF + " / 2 )";
                price.text = "2000000";
                Debug.Log("Module5");
                rebutton.onClick.AddListener(MF);

                break;

            case "Module6":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "나노 모터";
                infotext.text = "공격력 + 5";
                //btntext.text = "개조하기( " + useMM + " / 3 )";
                price.text = "4000000";
                Debug.Log("Module6");
                rebutton.onClick.AddListener(MM);

                break;

            case "Module7":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "파워 사이펀";
                infotext.text = "공격력 + 10";
                //btntext.text = "개조하기( " + usePS + " / 3 )";
                price.text = "8000000";
                Debug.Log("Module7");
                rebutton.onClick.AddListener(PS);

                break;
            //-------------방어력-------------//
            case "Module8":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "담금질";
                infotext.text = "방어력 + 2";
                //btntext.text = "개조하기( " + useQC + " / 2 )";
                price.text = "1000000";
                Debug.Log("Module8");
                rebutton.onClick.AddListener(QC);

                break;

            case "Module9":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "고밀도 외골격";
                infotext.text = "방어력 + 3";
                //btntext.text = "개조하기( " + useHDE + " / 2 )";
                price.text = "2000000";
                Debug.Log("Module9");
                rebutton.onClick.AddListener(HDE);

                break;

            case "Module10":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "티타늄 코팅";
                infotext.text = "방어력 + 5";
                //btntext.text = "개조하기( " + useTC + " / 3 )";
                price.text = "4000000";
                Debug.Log("Module10");
                rebutton.onClick.AddListener(TC);

                break;

            case "Module11":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "순간 경질화 시스템";
                infotext.text = "방어력 + 10";
                //btntext.text = "개조하기( " + useIHS + " / 3 )";
                price.text = "8000000";
                Debug.Log("Module11");
                rebutton.onClick.AddListener(IHS);

                break;

            //-------------무게-------------//

            case "Module12":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "중량화";
                infotext.text = "공격력 - 5, 방어력 + 6";
                //if (useW) { btntext.text = "개조하기( 1 / 1 )"; }
                //else { btntext.text = "개조하기( 0 / 1)"; }
                price.text = "5000000";
                Debug.Log("Module12");
                rebutton.onClick.AddListener(HW);

                break;

            case "Module13":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "경량화";
                infotext.text = "방어력 - 5, 공격력 + 6";
                //if (useW) { btntext.text = "개조하기( 1 / 1 )"; }
                //else { btntext.text = "개조하기( 0 / 1)"; }
                price.text = "5000000";
                Debug.Log("Module13");
                rebutton.onClick.AddListener(LW);

                break;

            //===========다리==========//

            case "Module14":

                temp = btnName;
                rebutton.name = temp;
                nametext.text = "강화 골격";
                infotext.text = "이동 수치 보정 + 1";
                //if (useRS) { btntext.text = "개조하기( 1 / 1 )"; }
                //else { btntext.text = "개조하기( 0 / 1)"; }
                price.text = "1000000";
                Debug.Log("Module14");
                rebutton.onClick.AddListener(RS);
                break;


            //===========주머니==========//

            case "Module15":
                temp = btnName;
                rebutton.name = temp;
                nametext.text = "인감 덧대기";
                infotext.text = "주머니 속 한 줄을 해금한다.";
                //btntext.text = "개조하기( " + useNewPocket + " / 3 )";
                price.text = "1000000";
                Debug.Log("Module15");
                rebutton.onClick.AddListener(NewPocket);

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





    // Update is called once per frame
    void Update()
    {
        if(btnName == "Module1")
        {
            if (useIQM == true)
            {
                btntext.text = "개조하기( 1 / 1 )";
            }
            else if (useIQM == false) { btntext.text = "개조하기( 0 / 1 )"; Debug.Log(useIQM); }
        }

        else if(btnName == "Module2")
        {
            if (useEM == true)
            {
                btntext.text = "개조하기( 1 / 1 )";
            }
            else if (useEM == false) { btntext.text = "개조하기( 0 / 1 )"; Debug.Log(useEM); }
        }

        else if(btnName == "Module3")
        {
            if (useHM == true)
            {
                btntext.text = "개조하기( 1 / 1 )";
            }
            else if (useHM == false) { btntext.text = "개조하기( 0 / 1 )"; Debug.Log(useHM); }
        }

        else if(btnName == "Module4")
        {
            btntext.text = "개조하기( " + useIH + " / 2 )";
        }

        else if (btnName == "Module5")
        {
            btntext.text = "개조하기( " + useMF + " / 2 )";
        }

        else if (btnName == "Module6")
        {
            btntext.text = "개조하기( " + useMM + " / 3 )";
        }

        else if (btnName == "Module7")
        {
            btntext.text = "개조하기( " + usePS + " / 3 )";
        }

        else if (btnName == "Module8")
        {
            btntext.text = "개조하기( " + useQC + " / 2 )";
        }

        else if (btnName == "Module9")
        {
            btntext.text = "개조하기( " + useHDE + " / 2 )";
        }

        else if (btnName == "Module10")
        {
            btntext.text = "개조하기( " + useTC + " / 3 )";
        }

        else if (btnName == "Module11")
        {
            btntext.text = "개조하기( " + useIHS + " / 3 )";
        }

        else if (btnName == "Module12")
        {
            if (useW) { btntext.text = "개조하기( 1 / 1 )"; }
            else { btntext.text = "개조하기( 0 / 1 )"; }
        }

        else if (btnName == "Module13")
        {
            if (useW) { btntext.text = "개조하기( 1 / 1 )"; }
            else { btntext.text = "개조하기( 0 / 1 )"; }
        }

        else if (btnName == "Module14")
        {
            if (useRS) { btntext.text = "개조하기( 1 / 1 )"; }
            else { btntext.text = "개조하기( 0 / 1 )"; }
        }

        else if (btnName == "Module15")
        {
            btntext.text = "개조하기( " + useNewPocket + " / 3 )";
        }




        //Use();
        Debug.Log("현재 돈은 " + _money);
        Debug.Log("현재 공격력은 " + _atkPoint);
        Debug.Log("현재 방어력은 " + _defPoint);



    }



}

