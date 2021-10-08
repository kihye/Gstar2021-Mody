using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BtnClick : MonoBehaviour
{
    public void StartBtn()      //게임 시작 버튼
    {
        SoundManager.instance.PlaySFX("Click");

        //저장된 데이터 파일이 존재한다면
        if (SLManager.instance.SearchData() == true)
        {
            UIManager.instance.SetPopup(
                                        "저장된 데이터가 존재합니다.\n데이터를 지우고 새로 시작하시겠습니까?",
                                        "예",
                                        "아니오",
                                        () => {                                                                         //동기 방식 씬 로딩 함수     //나중에 바꿔야
                                                    SLManager.instance.DeleteData();    //저장되있던 데이터 파일 삭제
                                                    SceneManager.LoadScene("Main");
                                                    SoundManager.instance.PlayBGM("B2"); SoundManager.instance.PlaySFX("Water");
                                              },
                                        () => { 
                                                    SLManager.instance.LoadData();
                                                    SceneManager.LoadScene("Main");
                                                    SoundManager.instance.PlaySFX("Water");
                                              }
                                    );
        }
        //저장된 데이터 파일이 없다면
        else
        {
            UIManager.instance.SetPopup
            (
                "당신의 이름을 작성하십시오.",
                "닫기",
                "확인",
                () => {
                            
                      },
                () => {
                            PlayerData.getsetName = UIManager.instance.inputMsg.GetComponent<TMP_Text>().text;
                            SceneManager.LoadScene("MainMapScene");
                            SoundManager.instance.PlayBGM("B2");
                      },
                true
            );
        }
    }

    public void OptionBtn()         //환경설정 버튼
    {
        SoundManager.instance.PlaySFX("Click");
        UIManager.instance.OpenOption();
    }

    public void CloseOptionBtn()    //환경설정 닫기(확인) 버튼
    {
        SoundManager.instance.PlaySFX("Water");

        Option.ChangeOption();

        //OptionSet 비활성화
        UIManager.instance.CloseOption();
    }

    public void QuitBtn()       //게임 종료 버튼
    {
        SoundManager.instance.PlaySFX("Click");
        UIManager.instance.SetPopup(
                                        "게임을 종료하시겠습니까?",
                                        "예",
                                        "아니오",
                                        () => { Application.Quit(); },
                                        () => { 
                                                    SoundManager.instance.PlaySFX("Water");
                                                    UIManager.instance.ClosePopup();
                                              }
                                    );
    }

    public void SaveBtn1()      //data1 저장하기 버튼
    {
        SoundManager.instance.PlaySFX("Click");

        DataInfo d1 = new DataInfo("두만식", 1000, 2000);
        SLManager.instance.SaveData(d1);
    }

    public void SaveBtn2()      //data2 저장하기 버튼
    {
        SoundManager.instance.PlaySFX("Click");

        DataInfo d2 = new DataInfo("곽두팔", 5000, 75000);
        SLManager.instance.SaveData(d2);
    }

    public void LoadBtn()       //불러오기 버튼
    {
        SoundManager.instance.PlaySFX("Click");

        if (SLManager.instance.SearchData() != true)
        {
            UIManager.instance.SetPopup(
                                        "저장된 데이터가 없습니다.\n게임을 종료하시겠습니까?",
                                        "예",
                                        "아니오",
                                        () => { Application.Quit(); },
                                        () => { SoundManager.instance.PlaySFX("Water"); UIManager.instance.ClosePopup(); }
                                    );
        }
        else
        {
            SLManager.instance.LoadData();
        }
    }

    public void OpenInvenBtn()      //주머니(인벤토리) 버튼
    {
        SoundManager.instance.PlaySFX("Click");

        UIManager.instance.OpenInven();
        Debug.Log(PlayerData.getsetName);
    }

    public void CloseInvenBtn()     //주머니(인벤토리) 닫기 버튼
    {
        SoundManager.instance.PlaySFX("Water");

        UIManager.instance.CloseInven();
    }
}
