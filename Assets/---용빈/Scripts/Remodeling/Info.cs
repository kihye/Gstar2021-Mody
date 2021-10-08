using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Info :  Remodeling
{
    public Image image;
    public Text nametext;
    public Text infotext;
    public Button rebutton;
    public Text btntext;
    public Text price;
    string btnName;

public void ClickBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        btnName = clickObject.name;
    }

    // Update is called once per frame
    void Update()
  
        {    switch (btnName)
            {
                //===========안구==========//
                case "Module1":
                    nametext.text = "정보 수치화 모듈";
                    infotext.text = "전투 시 적의 다음 행동을 수치화하여 볼 수 있다.";
                if (useIQM == true)
                {
                    btntext.text = "개조하기( 1 / 1 )";
                    Debug.Log("AAA");
                }
                else btntext.text = "개조하기( 0 / 1 )";
                    price.text = "1000000";
                    Debug.Log("Module1");
                    rebutton.onClick.AddListener(IQM);

                    break;

                case "Module2":
                    nametext.text = "탐색 모듈";
                    infotext.text = "적의 상세한 스테이터스를 볼 수 있다.";
                    btntext.text = "개조하기( 1 / 1 )";
                    price.text = "1000000";
                    Debug.Log("Module2");
                rebutton.onClick.AddListener(EM);

                break;

                case "Module3":
                    nametext.text = "해킹 모듈";
                    infotext.text = "전투에서 승리할 경우, 적의 시체에서 더 많은 현금을 찾아낸다.";
                    btntext.text = "개조하기( 1 / 1 )";
                    price.text = "1000000";
                    Debug.Log("Module3");
                rebutton.onClick.AddListener(HM);

                break;

                //===========팔==========//

                //-------------공격력-------------//
                case "Module4":
                    nametext.text = "외피 연마";
                    infotext.text = "공격력 + 2";
                    btntext.text = "개조하기( 2 / 2 )";
                    price.text = "1000000";
                    Debug.Log("Module4");
                rebutton.onClick.AddListener(IH);

                break;

                case "Module5":
                    nametext.text = "근섬유 수축기";
                    infotext.text = "공격력 + 3";
                    btntext.text = "개조하기( 2 / 2 )";
                    price.text = "2000000";
                    Debug.Log("Module5");
                rebutton.onClick.AddListener(MF);

                break;

                case "Module6":
                    nametext.text = "나노 모터";
                    infotext.text = "공격력 + 5";
                    btntext.text = "개조하기( 3 / 3 )";
                    price.text = "4000000";
                    Debug.Log("Module6");
                rebutton.onClick.AddListener(MM);

                break;

                case "Module7":
                    nametext.text = "파워 사이펀";
                    infotext.text = "공격력 + 10";
                    btntext.text = "개조하기( 3 / 3 )";
                    price.text = "8000000";
                    Debug.Log("Module7");
                rebutton.onClick.AddListener(PS);

                break;
                //-------------방어력-------------//
                case "Module8":
                    nametext.text = "담금질";
                    infotext.text = "방어력 + 2";
                    btntext.text = "개조하기( 2 / 2 )";
                    price.text = "1000000";
                    Debug.Log("Module8");
                rebutton.onClick.AddListener(QC);

                break;

                case "Module9":
                    nametext.text = "고밀도 외골격";
                    infotext.text = "방어력 + 3";
                    btntext.text = "개조하기( 2 / 2 )";
                    price.text = "2000000";
                    Debug.Log("Module9");
                rebutton.onClick.AddListener(HDE);

                break;

                case "Module10":
                    nametext.text = "티타늄 코팅";
                    infotext.text = "방어력 + 5";
                    btntext.text = "개조하기( 3 / 3 )";
                    price.text = "4000000";
                    Debug.Log("Module10");
                rebutton.onClick.AddListener(TC);

                break;

                case "Module11":
                    nametext.text = "순간 경질화 시스템";
                    infotext.text = "방어력 + 10";
                    btntext.text = "개조하기( 3 / 3 )";
                    price.text = "8000000";
                    Debug.Log("Module11");
                rebutton.onClick.AddListener(IHS);

                break;

                //-------------무게-------------//

                case "Module12":
                    nametext.text = "중량화";
                    infotext.text = "공격력 - 5, 방어력 + 6";
                    btntext.text = "개조하기( 1 / 1 )";
                    price.text = "5000000";
                    Debug.Log("Module12");
                rebutton.onClick.AddListener(HW);

                break;

                case "Module13":
                    nametext.text = "경량화";
                    infotext.text = "방어력 - 5, 공격력 + 6";
                    btntext.text = "개조하기( 1 / 1 )";
                    price.text = "5000000";
                    Debug.Log("Module13");
                rebutton.onClick.AddListener(LW);

                break;

                //===========다리==========//

                case "Module14":
                    nametext.text = "강화 골격";
                    infotext.text = "이동 수치 보정 + 1";
                    price.text = "1000000";
                    Debug.Log("Module14");
                rebutton.onClick.AddListener(RS);

                break;


                //===========주머니==========//

                case "Module15":
                    nametext.text = "인감 덧대기";
                    infotext.text = "주머니 속 한 줄을 해금한다.";
                    price.text = "1000000";
                    Debug.Log("Module15");
                rebutton.onClick.AddListener(NewPocket);
                
                break;
            }
        }
    }





