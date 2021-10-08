using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_EnemyDictionary : MonoBehaviour
{
    public EnemyData[] enemyDatas = new EnemyData[9];
    private EnemyData.EnemyLevel eLevel;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 9; i++)
        {

            switch(i / 3)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
