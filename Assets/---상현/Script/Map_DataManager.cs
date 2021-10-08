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
    // Start is called before the first frame update
    void Start()
    {
        diceCount[0] = 0;
        diceCount[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BattleSceneMove()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
