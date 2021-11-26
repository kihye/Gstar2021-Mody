using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map_DataManager : MonoBehaviour
{
    public static int[] diceCount = new int[2];
    public static int diceCountSum = 0;

    public static bool isCanMove = false;
    public static int myDiceCount = 1;

    public static bool isClear = false;
    public static bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        diceCount[0] = 0;
        diceCount[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(System_MainDataManager.mainData.isDebugMode)
        {
            if (Input.GetKeyDown(KeyCode.F6))
            {
                BattleSceneMove();
            }
            if(Input.GetKeyDown(KeyCode.F7))
            {
                isClear = true;
            }
        }
    }
    public void BattleSceneMove()
    {
        System_MainDataManager.fieldEnemyData = 0;
        LoadingSceneManager.LoadScene("BattleScene");
    }
    public void BattleSceneLv1()
    {
        System_MainDataManager.fieldEnemyData = 0;
        LoadingSceneManager.LoadScene("BattleScene");
    }
    public void BattleSceneLv2()
    {
        System_MainDataManager.fieldEnemyData = 1;
        LoadingSceneManager.LoadScene("BattleScene");
    }
    public void BattleSceneLv3()
    {
        System_MainDataManager.fieldEnemyData = 2;
        LoadingSceneManager.LoadScene("BattleScene");
    }
    public void TitleSceneMove()
    {
        LoadingSceneManager.LoadScene("TitleScene");
    }
    public void ClearMove()
    {
        isClear = false;
        isMoving = false;
        isCanMove = false;
        LoadingSceneManager.LoadScene("TitleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
