using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private UI_Player p_UI;
    [SerializeField] private UI_Enemy e_UI;
    [SerializeField] private UI_System s_UI;

    [SerializeField] private DropActive drop;

    public static bool isBattle = false;
    
    [SerializeField]
    private System_BattleManager bManager;
    [SerializeField]
    private Inventory inven;

    public Enemy_AI_Images iContainer;

    public Slider[] enemyHp = new Slider[4];
    public Text[] enemyHpText = new Text[4];
    public GameObject[] enemyHpGo = new GameObject[4];

    public SpriteRenderer[] enemyImages = new SpriteRenderer[4];

    public GameObject[] targetImages = new GameObject[4];
    public GameObject[] enemyGo = new GameObject[4];
    public GameObject[] enemyAi = new GameObject[4];

    public Image[] enemyAiImages = new Image[4];

    public Text[] enemyNames = new Text[4];

    private Color[] enemyColors = new Color[4];

    public GameObject clearWindow;
    public GameObject deadWindow;

    public Text rewardText;

    public Item rewardItem;

    private void Awake()
    {
        bManager = GameObject.Find("BattleManager").GetComponent<System_BattleManager>();
    }

    private void Start()
    {

        p_UI.UIActive(true);
        BindUI();
        clearWindow.SetActive(false);

        InitializeEnemies(bManager.enemyCount);
        InitializeTargetInfo(bManager.enemyCount);
        InitializeBattleUI(bManager);

        inven = GameObject.Find("UIManager").transform.GetChild(0).GetChild(1).GetComponent<Inventory>();
    }
    public void addItem()
    {
        if(rewardItem != null)
            inven.AddItemToInven(rewardItem);
    }
    void Update()
    {
        if(isBattle)
        {
            if(!System_BattleManager.isPlayerDead)
            {
                for(int i = 0; i < 2; i++)
                {
                    if (bManager.buffTimeAndCnt[i, 0] > 0)
                        s_UI.ActiveBuffUI(i, true, bManager);
                    else
                        s_UI.ActiveBuffUI(i, false, bManager);
                }
                s_UI.GetTextData(bManager);
                p_UI.GetUIDatas(bManager);
                ActiveTargetHpInfo(bManager.enemyCount);
                if (bManager.IsCleared())
                {
                    drop.RollDrop();

                    rewardItem = drop.selectedItem;

                    p_UI.UIActive(false);
                    clearWindow.SetActive(true);
                    rewardText.text = "보상 금액 : " + System_MainDataManager.mainData.MoneyText(bManager.RewardMoney());
                }
                else
                {
                    if (!bManager.isEnemyAttack)
                        ActiveTargetImage(bManager.targetEnemy, bManager.enemyCount);
                    else
                    {
                        ActiveTargetImage(bManager.targetEnemy, bManager.enemyCount, bManager.enemyActionIndex, false);
                    }
                    p_UI.ActiveSkillInfo(System_MainDataManager.MaxSkillNum, bManager);
                    for (int i = 0; i < bManager.enemyCount; i++)
                    {
                        if (!bManager.eData[i].isAlive) enemyGo[i].SetActive(false);
                        if(System_MainDataManager.mainData.rm_IQM)
                        {
                            e_UI.EnemyInfoView(i, bManager.eData[i]);
                        }
                    }
                }
            }
            else
            {
                p_UI.UIActive(false);
                deadWindow.SetActive(true);
            }
        }
    }
    private void BindUI()
    {
        p_UI.BindDatas();
        e_UI.BindDatas();
        s_UI.BindDatas();
    }
    public void AttackEnemy(System_BattleManager bm) // 공격버튼으로 호출됨
    {
        bm.BasicAttack();
    }
    public void InitializeBattleUI(System_BattleManager bm)
    {
        p_UI.InitializePlayerSkills(System_MainDataManager.MaxSkillNum, bm);
        p_UI.InitializeUIDatas(bm);
    }
    private void ActiveTargetImage(int target, int enemyNum, int enemyTargetNum = 0, bool isActive = true)
    {
        if(isActive)
        {
            for (int i = 0; i < enemyNum; i++)
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
        else
        {
            for(int i = 0; i < enemyNum; i++)
            {
                if(i == target)
                    targetImages[i].SetActive(false);
                if (i == enemyTargetNum)
                    enemyColors[i].a = 1f;
                else
                    enemyColors[i].a = 0.5f;
                enemyImages[i].color = enemyColors[i];
            }
        }
    }
    private void ActiveTargetHpInfo(int enemyNum)
    {
        for(int i = 0; i < enemyNum; i++)
        {
            enemyHp[i].value = bManager.eData[i]._curHp;
            enemyHpText[i].text = enemyHp[i].value.ToString();
            //Get<Text>((int)Texts.Enemy_HP_Text_ + (i+1)).text = enemyHp[i].value.ToString(); //실험 부분
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
            enemyNames[i].text = bManager.eData[i]._enemyName;
        }
    }
    
    public void MoveScene()
    {
        System_MainDataManager.mainData.isBattleScene = false;
        LoadingSceneManager.LoadScene("MainMapScene");
    }
    public void DeadMove()
    {
        System_MainDataManager.mainData.DeadControl();
        MoveScene();
    }
}
