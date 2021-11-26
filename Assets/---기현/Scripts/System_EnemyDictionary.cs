using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_EnemyDictionary : MonoBehaviour
{
    public EnemyData[] enemyDatas = new EnemyData[9];
    private EnemyData.EnemyLevel eLevel;
    private EnemyData.EnemyType eType;

    // Start is called before the first frame update
    public void EnemyGenerate()
    {
        for (int i = 0; i < 9; i++)
        {
            enemyDatas[i] = new EnemyData();
        }
        for (int i = 0; i < 9; i++)
        {
            switch (i / 3)
            {
                case 0:
                    eLevel = EnemyData.EnemyLevel.Low;
                    break;
                case 1:
                    eLevel = EnemyData.EnemyLevel.Middle;
                    break;
                case 2:
                    eLevel = EnemyData.EnemyLevel.High;
                    break;
            }
            switch (i % 3)
            {
                case 0:
                    eType = EnemyData.EnemyType.Offense;
                    break;
                case 1:
                    eType = EnemyData.EnemyType.Balance;
                    break;
                case 2:
                    eType = EnemyData.EnemyType.Defense;
                    break;
            }
            enemyDatas[i].MakeEnemy(eLevel, eType);
        }
    }
}
