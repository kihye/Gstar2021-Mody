using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public Inventory inven;

    public void BuyBolt1()
    {
        for (int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].item == null)
            {
                //inven.AddItemToInven();
            }
        }
    }
}
