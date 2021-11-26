using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : BaseUI
{
    enum Sliders
    {
        Player_Hp_Slider
    }
    enum Texts
    {
        Player_Hp_Text
    }
    [SerializeField]
    private System_SkillDictionary sDict;

    [SerializeField]
    private GameObject uiCanvas;

    public Button[] playerSkillButtons = new Button[4];
    private Text[] playerSkillName = new Text[4];
    public Text[] playerSkillTexts = new Text[4];
    public Text[] playerSkillCoolTimeTexts = new Text[4];
    
    public void UIActive(bool active)
    {
        if (active)
            uiCanvas.SetActive(true);
        else
            uiCanvas.SetActive(false);
    }
    public void ActiveSkillInfo(int skillNum, System_BattleManager bManager)
    {
        for (int i = 0; i < skillNum; i++)
        {
            if (System_MainDataManager.mainData.skillUnlocked[i])
            {
                playerSkillTexts[i].text = sDict.skillDatas[i].sInfo;
                playerSkillCoolTimeTexts[i].text = bManager.skillCoolTime[i].ToString();
            }
        }
    }
    public void InitializePlayerSkills(int skillNum, System_BattleManager bManager)
    {
        for (int i = 0; i < 4; i++)
        {
            playerSkillButtons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < skillNum; i++)
        {
            if (System_MainDataManager.mainData.skillUnlocked[i])
            {
                int temp = i;   // 람다식 클로저 문제(마지막 값으로 통일됨) 문제로 인해 임시로 변수를 선언함
                playerSkillButtons[i].gameObject.SetActive(true);

                //if (sDict.skillDatas[temp]._type == System_SkillData.SkillType._isAttack)
                playerSkillButtons[temp].onClick.AddListener(() => bManager.UseSkill(sDict.skillDatas[temp]));

                playerSkillName[i] = playerSkillButtons[i].transform.GetChild(0).GetComponent<Text>();
                playerSkillName[i].text = sDict.skillDatas[i].sName;
            }
        }
    }
    public override void BindDatas()
    {
        //Bind<Button>(typeof(Buttons), parent);
        Bind<Slider>(typeof(Sliders), parent);
        Bind<Text>(typeof(Texts), parent);
    }
    public void GetUIDatas(System_BattleManager bManager)
    {
        GetTextData(bManager);
        GetSliderData(bManager);
    }
    public void InitializeUIDatas(System_BattleManager bManager)
    {
        InitializeDatas(bManager);
    }
    private void InitializeDatas(System_BattleManager bManager)
    {
        Get<Slider>((int)Sliders.Player_Hp_Slider).maxValue = bManager.pData._maxHp;
    }
    private void GetTextData(System_BattleManager bManager)
    {
        Get<Text>((int)Texts.Player_Hp_Text).text = Get<Slider>((int)Sliders.Player_Hp_Slider).value.ToString();
    }
    private void GetSliderData(System_BattleManager bManager)
    {
        Get<Slider>((int)Sliders.Player_Hp_Slider).value = bManager.pData._curHp;
    }
}
