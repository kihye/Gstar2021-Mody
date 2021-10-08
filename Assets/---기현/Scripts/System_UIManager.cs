using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class System_UIManager : MonoBehaviour
{
    public System_BattleManager bManager;
    public System_SkillDictionary sDict;

    public Slider playerHp;
    public Text playerHpText;
    public Text playerAtkText;
    public Text playerDefText;

    public Button[] playerSkillButtons = new Button[4];
    private Text[] playerSkillName = new Text[4];
    public Text[] playerSkillTexts = new Text[4];

    public Slider[] enemyHp = new Slider[4];
    public Text[] enemyHpText = new Text[4];
    public GameObject[] enemyHpGo = new GameObject[4];

    public Image[] enemyImages = new Image[4];
    public GameObject[] targetImages = new GameObject[4];
    public GameObject[] enemyGo = new GameObject[4];
    public GameObject[] enemyAi = new GameObject[4];
    public Text[] enemyAiText = new Text[4];

    private Color[] enemyColors = new Color[4];

    public Text turnText;
    public Text diceText;

    public GameObject clearWindow;

    private void Awake()
    {
        sDict = GameObject.Find("SkillDictionary").GetComponent<System_SkillDictionary>();
    }

    private void Start()
    {
        clearWindow.SetActive(false);

        playerHp.maxValue = bManager.pData._maxHp;

        InitializeEnemies(bManager.enemyCount);
        InitializeTargetInfo(bManager.enemyCount);
        InitializePlayerSkills(bManager.skillCount);
    }

    // Update is called once per frame
    void Update()
    {
        ActiveTargetHpInfo(bManager.enemyCount);
        if (bManager.IsCleared())
        {
            clearWindow.SetActive(true);
        }
        else
        {
            playerHp.value = bManager.pData._curHp;
            playerHpText.text = playerHp.value.ToString();

            playerAtkText.text = "공격력 : " + bManager.pData._atkPoint;
            playerDefText.text = "방어력 : " + bManager.pData._defPoint;

            turnText.text = "턴 : " + bManager.turnCount;

            diceText.text = "주사위 : " + "|" + bManager.diceCount[0] + "| |" + bManager.diceCount[1] + "|";

            ActiveTargetImage(bManager.targetEnemy, bManager.enemyCount);
            ActiveSkillInfo(bManager.skillCount);
            for(int i = 0; i < bManager.enemyCount; i++)
            {
                if (!bManager.eData[i].isAlive) enemyGo[i].SetActive(false);
            }
        }
    }
    public void AttackEnemy() // 공격버튼으로 호출됨
    {
        bManager.CalAttackDamage();   
    }
    public void SkillAttackEnemy(int sIndex)
    {
        bManager.CalAttackDamage(sIndex);
    }
    private void ActiveTargetImage(int target, int enemyNum)
    {
        for(int i = 0; i < enemyNum; i++)
        {
            if (i == target)
            {
                targetImages[i].SetActive(true);
                enemyColors[i].a = 1f;
            }
            else
            {
                targetImages[i].SetActive(false);
                enemyColors[i].a = 0.5f;
            }
            enemyImages[i].color = enemyColors[i];
        }
    }
    private void ActiveTargetHpInfo(int enemyNum)
    {
        for(int i = 0; i < enemyNum; i++)
        {
            enemyHp[i].value = bManager.eData[i]._curHp;
            enemyHpText[i].text = enemyHp[i].value.ToString();
        }
    }
    private void ActiveSkillInfo(int skillNum)
    {
        for(int i = 0; i < skillNum; i++)
        {
            playerSkillTexts[i].text = sDict.skillDatas[i].sInfo;
        }
    }
    private void InitializeTargetInfo(int enemyNum)
    {
        for (int i = 0; i < enemyNum; i++)
        {
            enemyHp[i].maxValue = bManager.eData[i]._maxHp;
            enemyColors[i] = enemyImages[i].color;
        }
    }
    private void InitializeEnemies(int enemyNum)
    {
        for(int i = 0; i < 4; i++)
        {
            enemyGo[i].SetActive(false);
            enemyHpGo[i].SetActive(false);
            enemyAi[i].SetActive(false);
        }
        for(int i = 0; i < enemyNum; i++)
        {
            enemyGo[i].SetActive(true);
            enemyHpGo[i].SetActive(true);
            enemyAi[i].SetActive(true);
            enemyAiText[i] = enemyAi[i].transform.GetChild(1).GetComponent<Text>();
        }
    }
    private void InitializePlayerSkills(int skillNum)
    {
        for(int i = 0; i < 4; i++)
        {
            playerSkillButtons[i].gameObject.SetActive(false);
        }
        for(int i = 0; i < skillNum; i++)
        {
            int temp = i;   // 클로저 문제(마지막 값으로 통일됨) 문제로 인해 임시로 변수를 선언함
            playerSkillButtons[i].gameObject.SetActive(true);   

            if(sDict.skillDatas[temp]._isAttack) playerSkillButtons[temp].onClick.AddListener(() => SkillAttackEnemy(sDict.skillDatas[temp]._sIndex));

            playerSkillName[i] = playerSkillButtons[i].transform.GetChild(0).GetComponent<Text>();
            playerSkillName[i].text = sDict.skillDatas[i].sName;
        }
    }
    public void MoveScene()
    {
        SceneManager.LoadScene("MainMapScene");
    }
}
