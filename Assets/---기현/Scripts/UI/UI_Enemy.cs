using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Enemy : BaseUI
{
    public GameObject[] enemyInfo = new GameObject[4];
    public Text[] enemyInfoAtk = new Text[4];
    public Text[] enemyInfoDef = new Text[4];

    public override void BindDatas()
    {
        //Bind<Button>(typeof(Buttons), parent);
        //Bind<Slider>(typeof(Sliders), parent);
        //Bind<Text>(typeof(Texts), parent);
    }
    public void EnemyInfoView(int enemyIndex, Enemy_BattleData enemy)
    {
        enemyInfo[enemyIndex].SetActive(true);
        enemyInfoAtk[enemyIndex].text = enemy._atkPoint.ToString();
        enemyInfoDef[enemyIndex].text = enemy._defPoint.ToString();
    }
}
