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
    public ShopManager shop;
    private int invenCount = 0;
    private void Start()
    {
        if(slots.Length == 0)
            slots = slotList.GetComponentsInChildren<Slot>();
        for (int i = 6; i < 24; i++)
        {
            Transform trChild = slotList.transform.GetChild(i);
            trChild.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //개조부분에서InventoryUpgrade()넣어주면 될듯
        {
            invenCount++;
            InventoryUpgrade();
        }
    }
    public void InventoryUpgrade()
    {
        switch (invenCount)
        {
            case 1:
                for (int i = 6; i < 12; i++)
                {
                    Transform trChild = slotList.transform.GetChild(i);
                    trChild.gameObject.SetActive(true);
                }
                break;
            case 2:
                for (int i = 12; i < 18; i++)
                {
                    Transform trChild = slotList.transform.GetChild(i);
                    trChild.gameObject.SetActive(true);
                }
                break;
            case 3:
                for (int i = 18; i < 24; i++)
                {
                    Transform trChild = slotList.transform.GetChild(i);
                    trChild.gameObject.SetActive(true);
                }
                break;
        }
    }
    public void AddItemToInven(Item _item, int count = 1)
    {
        //Debug.Log(_item);
        if (slots.Length == 0)
            slots = slotList.GetComponentsInChildren<Slot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null) //해당 자리에 아이템이 존재하지 않는다면
            {
                slots[i].AddItem(_item);
                return;
            }

        }
    }
}
