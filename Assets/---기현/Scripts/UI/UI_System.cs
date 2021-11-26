using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_System : BaseUI
{
    public GameObject atkBuffGo;
    public GameObject defBuffGo;

    public Text atkTimeText;
    public Text atkApplyText;
    public Text defTimeText;
    public Text defApplyText;

    enum Texts
    {
        Player_Atk_Text,
        Player_Def_Text,
        Turn_Text,
        Dice_Text,
    }
    public override void BindDatas()
    {
        //Bind<Button>(typeof(Buttons), parent);
        //Bind<Slider>(typeof(Sliders), parent);
        Bind<Text>(typeof(Texts), parent);
    }
    public void GetTextData(System_BattleManager bManager)
    {
        Get<Text>((int)Texts.Player_Atk_Text).text = bManager.pData._atkPoint.ToString();
        Get<Text>((int)Texts.Player_Def_Text).text = bManager.pData._defPoint.ToString();

        Get<Text>((int)Texts.Turn_Text).text = bManager.turnCount.ToString();
        Get<Text>((int)Texts.Dice_Text).text = (bManager.diceCount[0] + bManager.diceCount[1]).ToString();
    }
    public void ActiveBuffUI(int num, bool isActive, System_BattleManager bManager)
    {
        if(num == 0)
        {
            atkBuffGo.SetActive(isActive);
            atkTimeText.text = bManager.buffTimeAndCnt[num, 0].ToString();
            atkApplyText.text = bManager.buffTimeAndCnt[num, 1].ToString();

        }
        else if(num == 1)
        {
            defBuffGo.SetActive(isActive);
            defTimeText.text = bManager.buffTimeAndCnt[num, 0].ToString();
            defApplyText.text = bManager.buffTimeAndCnt[num, 1].ToString();
        }
    }
}
