using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerData data = new PlayerData();

    public static GameObject PopupSet;
    public static GameObject OptionSet;
    public static GameObject InventorySet;


    //팝업창
    public TMP_Text msg;            //팝업창 본문 내용
    public Button btn1;             //팝업창 왼쪽 버튼
    public Button btn2;             //팝업창 오른쪽 버튼
    public TMP_Text btn1Text;       //팝업창 왼쪽 버튼의 텍스트
    public TMP_Text btn2Text;       //팝업창 오른쪽 버튼의 텍스트
    public GameObject inputfield;   //InputField 오브젝트
    public TMP_Text inputMsg;       //InputField의 텍스트

    public static UIManager instance;

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

        OptionSet = GameObject.Find("canvas").transform.GetChild(0).gameObject;     //canvas 오브젝트의 1번째 자식을 찾아서 대입
        InventorySet = GameObject.Find("canvas").transform.GetChild(1).gameObject;  //canvas 오브젝트의 2번째 자식을 찾아서 대입
        PopupSet = GameObject.Find("canvas").transform.GetChild(2).gameObject;      //canvas 오브젝트의 3번째 자식을 찾아서 대입
    }

    //
    // [ 팝업 ]
    public void SetPopup(string _msg, string _btn1, string _btn2, Action _act1, Action _act2, bool _onInputField = false)      //팝업창에 출력할 정보 설정 및 창 띄우기
    {
        msg.text = _msg;
        btn1Text.GetComponent<TMP_Text>().text = _btn1;
        btn2Text.GetComponent<TMP_Text>().text = _btn2;

        btn1.onClick.AddListener
        (
            () => {
                _act1();
                ClosePopup();
            }
        );
        
        btn2.onClick.AddListener
        (
            () => {
                _act2();
                ClosePopup();
            }
        );

        PopupSet.SetActive(true);

        if (_onInputField == true)
        {
            inputfield.SetActive(true);
        }
        else
        {
            inputfield.SetActive(false);
        }
    }

    public void ClosePopup()        //팝업창 비활성화
    {
        PopupSet.SetActive(false);
    }

    //
    // [ 옵션창 ]
    public void OpenOption()        //옵션창 활성화
    {
        OptionSet.SetActive(true);
    }

    public void CloseOption()       //옵션창 비활성화
    {
        OptionSet.SetActive(false);
    }

    //
    // [ 인벤토리창 ]
    public void OpenInven()         //인벤토리창 활성화
    {
        InventorySet.SetActive(true);
    }

    public void CloseInven()        //인벤토리창 비활성화
    {
        InventorySet.SetActive(false);
    }
}
