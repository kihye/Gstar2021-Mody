using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_AI_Images : MonoBehaviour
{
    public Image[] ai_Images;   // 0 == 공격, 1 == 방어

    public void SetImages(ref Image img, ref Quaternion rot, Enemy_BattleData.EnemyAI ai)
    {
        switch(ai)
        {
            case Enemy_BattleData.EnemyAI.Attack:
                img = ai_Images[0];
                rot.x = 180;
                rot.y = 0;
                rot.z = 0;
                break;
            case Enemy_BattleData.EnemyAI.Defense:
                img = ai_Images[1];
                rot.x = 0;
                rot.y = 0;
                rot.z = 0;
                break;
        }
    }
}
