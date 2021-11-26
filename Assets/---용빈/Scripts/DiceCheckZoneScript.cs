using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    private Vector3[] diceVelocity = new Vector3[2];
    private float timeset = 0f;
    private bool isTimeUp = false;

    private void FixedUpdate()
    {
        diceVelocity[0] = DiceControlManager.diceVelocity[0];
        diceVelocity[1] = DiceControlManager.diceVelocity[1];
        if(!DiceControlManager.isRolled)
        {
            timeset = 0f;
            isTimeUp = false;
        }
        if(DiceControlManager.isRolled && !isTimeUp)
        {
            timeset += Time.deltaTime;
            if (timeset > 0.2f)
            {
                isTimeUp = true;
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if(diceStayCheck(diceVelocity) && !DiceControlManager.diceChecked && DiceControlManager.isRolled && isTimeUp)
        {
            switch(col.gameObject.name)
            {    
                case "Side1":
                    Map_DataManager.diceCount[0] = 6;
                    break;
                case "Side2":
                    Map_DataManager.diceCount[0] = 5;
                    break;
                case "Side3":
                    Map_DataManager.diceCount[0] = 4;
                    break;
                case "Side4":
                    Map_DataManager.diceCount[0] = 3;
                    break;
                case "Side5":
                    Map_DataManager.diceCount[0] = 2;
                    break;
                case "Side6":
                    Map_DataManager.diceCount[0] = 1;
                    break;
            }
            if (Map_DataManager.myDiceCount > 1)
            {
                switch (col.gameObject.name)
                {
                    case "Side1-1":
                        Map_DataManager.diceCount[1] = 6;
                        break;
                    case "Side2-1":
                        Map_DataManager.diceCount[1] = 5;
                        break;
                    case "Side3-1":
                        Map_DataManager.diceCount[1] = 4;
                        break;
                    case "Side4-1":
                        Map_DataManager.diceCount[1] = 3;
                        break;
                    case "Side5-1":
                        Map_DataManager.diceCount[1] = 2;
                        break;
                    case "Side6-1":
                        Map_DataManager.diceCount[1] = 1;
                        break;
                }
                if (!DiceControlManager.diceChecked && Map_DataManager.diceCount[0] > 0 && Map_DataManager.diceCount[1] > 0)
                {
                    Map_DataManager.diceCountSum = Map_DataManager.diceCount[0] + Map_DataManager.diceCount[1];
                    Map_DataManager.isCanMove = true;
                    DiceControlManager.diceChecked = true;
                }
            }
            else
            {
                if (!DiceControlManager.diceChecked && Map_DataManager.diceCount[0] > 0)
                {
                    Map_DataManager.diceCountSum = Map_DataManager.diceCount[0];
                    Map_DataManager.isCanMove = true;
                    DiceControlManager.diceChecked = true;
                }
            }
            //Debug.Log(Map_DataManager.diceCount[0]);
            //Debug.Log(Map_DataManager.diceCount[1]);
        }
    }
    private bool diceStayCheck(Vector3[] diceVelocity)
    {
        for(int i = 0; i < Map_DataManager.myDiceCount; i++)
        {
            if (diceVelocity[i].x != 0) return false;
            if (diceVelocity[i].y != 0) return false;
            if (diceVelocity[i].z != 0) return false;
        }
        return true;
    }
}
