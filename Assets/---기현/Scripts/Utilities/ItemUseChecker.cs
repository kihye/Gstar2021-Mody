using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseChecker : MonoBehaviour
{
    [SerializeField] private System_BattleManager bManager;

    public void ApplyItem(Item item)
    {
        //Item item = inven.slots[slotNum].item;
        switch (item.itemType)
        {
            case Item.ItemType.Healing:
                bManager.pData._curHp += item.dataNum;
                break;
            case Item.ItemType.Buff:
                switch(item.buffType)
                {
                    case Item.BuffType.Atk:
                        bManager.buffTimeAndCnt[0, 0] = item.dataTurn;

                        if(bManager.buffTimeAndCnt[0, 1] <= 0)
                            bManager.buffTimeAndCnt[0, 1] = item.dataNum;
                        else
                            bManager.buffTimeAndCnt[0, 1] += item.dataNum;

                        bManager.pData._atkPoint += item.dataNum;
                        Debug.Log(bManager.pData._atkPoint);
                        break;
                    case Item.BuffType.Def:
                        bManager.buffTimeAndCnt[1, 0] = item.dataTurn;

                        if (bManager.buffTimeAndCnt[1, 0] <= 0)
                            bManager.buffTimeAndCnt[1, 1] = item.dataNum;
                        else
                            bManager.buffTimeAndCnt[1, 1] += item.dataNum;

                        bManager.pData._defPoint += item.dataNum;
                        break;
                }
                break;
            case Item.ItemType.Debuff:
                break;
        }
    }
}
