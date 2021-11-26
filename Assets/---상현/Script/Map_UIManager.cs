using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_UIManager : MonoBehaviour
{
    //public GameObject diceObj;
    public GameObject clearUI;
    public GameObject failUI;
    public Text clearDay;

    public Text diceCountText;
    public Text myMoneyText;
    public Text myDebtText;

    public Text payText;
    public Text turnText;
    private const int moneyDiv = 1000;

    void Update()
    {
        diceCountText.text = CalDiceCount().ToString();
        myMoneyText.text = System_MainDataManager.mainData.MoneyText(System_MainDataManager.mainData.playerMoney);
        myDebtText.text = System_MainDataManager.mainData.MoneyText(System_MainDataManager.mainData.playerDebt);
        turnText.text = System_MainDataManager.mainData.playerTurn.ToString();
        PayTextView();
        if(Map_DataManager.isClear)
        {
            clearUI.SetActive(true);
            clearDay.text = "변제 완료일 : " + System_MainDataManager.mainData.playerTurn + "일차";
        }
        else
        {
            if(System_MainDataManager.mainData.playerTurn == 100)
            {
                failUI.SetActive(true);
            }
            /*if (Map_DataManager.isMoving)
                diceObj.SetActive(false);
            else
                diceObj.SetActive(true);*/
        }
    }
    public void PayDebt()
    {

    }
    private int CalDiceCount()
    {
        if(Map_DataManager.isCanMove)
            return Map_DataManager.diceCountSum;

        return 0;
    }
    private int playerPayNum(int money, int debt)
    {
        if (money >= debt)
            return 0;

        return debt - money;
    }
    private string IsPayAble()
    {
        if(System_MainDataManager.mainData.playerMoney >= System_MainDataManager.mainData.playerDebt)
        {
            return "상납 가능";
        }
        return "상납 불가능";
    }
    private void PayTextView()
    {
        payText.text = "상납까지 : " + System_MainDataManager.mainData.MoneyText(playerPayNum(System_MainDataManager.mainData.playerMoney, System_MainDataManager.mainData.playerDebt))
            + " 남음" + "\n\n" + IsPayAble() + "\n\n" + "※반드시 일시불로 상납하시오.※";
    }
}
