using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public GameObject invenBG;
    [SerializeField]
    public GameObject slotList;

    public Slot[] slots;

    public void Start()
    {
        slots = slotList.GetComponentsInChildren<Slot>();       //각 슬롯 별 'Slot script'을 가져와 배열 slots에 넣기
    }

    public void AddItemToInven(Item _item, int count = 1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null) //해당 자리에 아이템이 존재하지 않는다면
            {
                slots[i].AddItem(_item);
                return;
            }
        }

        Debug.Log("인벤토리가 가득 찼다!");
    }
}
