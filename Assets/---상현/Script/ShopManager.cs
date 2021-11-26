using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using System.Text.RegularExpressions;
public class ShopManager : MonoBehaviour
{
    public ShopItemDatas shopItemDatas;
    public GameObject itemSC;

    public GameObject buyItem;
    public Text number;
    public Text price;
    public Image curImage;

    public Transform shopTr;

    public static int slotNum = 0;

    private int itemCount;
    private int allPrice;
    private Sprite buyImage;
    private Inventory inven;
    private GameObject Go;

    private void Start()
    {
        for(int i = 0; i < shopItemDatas.items.Length; i++)
        {
            itemSC.GetComponentInChildren<ItemSC>().itemData = shopItemDatas.items[i];
            GameObject shops = Instantiate(itemSC, new Vector3(
                shopTr.position.x - 360 + 360 * (i % 3), 
                shopTr.position.y + 160 - 240 * (i / 3), 
                shopTr.position.z
                ), Quaternion.identity, shopTr);
        }
        
        itemCount = int.Parse(number.text);
        inven = GameObject.Find("UIManager").transform.GetChild(0).GetChild(1).GetComponent<Inventory>();
    }
    private void Update()
    {
        //curMoney.text = "MyMoney : $" + System_MainDataManager.mainData.playerMoney.ToString("#,##0");
        //myMoney = Regex.Replace(curMoney.text, @"[^0-9]", "");

        if (Slot.isSell == true)
        {
            System_MainDataManager.mainData.playerMoney += Slot.sellPrice;    
            Slot.isSell = false;
        }
    }

    public void ChangeItemInfo()
    {
        buyImage = Go.GetComponent<Image>().sprite;
        curImage.sprite = buyImage;

        price.text = Go.GetComponentInChildren<Text>().text;

        itemCount = 1;
        number.text = itemCount.ToString();
    }

    public void Stroe()
    {
        this.gameObject.SetActive(true);
    }
    public void ClickItem()
    {
        if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponent<ItemSC>() != null)
        {
            Go = EventSystem.current.currentSelectedGameObject;
        }
        buyItem.SetActive(true);
    }
    public void ClickCancleBtn()
    {
        buyItem.SetActive(false);
    }
    public void ClickBuyBtn()
    {
        int remainInven = 0;
        for (int i = 0; i < inven.slots.Length; i++)
        {
            if (!inven.slots[i].gameObject.activeSelf)
                break;
            else
            {
                if (inven.slots[i].item == null)
                    remainInven++;
                if (remainInven == 5)
                    break;
            }
        }
        if(remainInven > 0)
        {
            for (int i = 0; i < itemCount; i++)
            {
                inven.AddItemToInven(Go.GetComponent<ItemSC>().itemData, 1);
            }
            if (itemCount == 1)
                allPrice = Go.GetComponent<ItemSC>().itemData.purchasePrice;
            System_MainDataManager.mainData.playerMoney -= allPrice;
            buyItem.SetActive(false);
        }
    }
    public void ClickLeftBtn()
    {
        if (itemCount > 1)
        {
            itemCount--;
            allPrice -= Go.GetComponent<ItemSC>().itemData.purchasePrice;
            number.text = itemCount.ToString();
            price.text = Go.GetComponent<ItemSC>().itemData.itemName + " : " + allPrice.ToString("#,##0") + "$";
        }
    }
    public void ClickRightBtn()
    {
        int remainInven = 0;
        for(int i = 0; i < inven.slots.Length; i++)
        {
            if (!inven.slots[i].gameObject.activeSelf)
                break;
            else
            {
                if (inven.slots[i].item == null)
                    remainInven++;
                if (remainInven == 5)
                    break;
            }
        }
        itemCount++;
        if (itemCount > remainInven)
        {
            itemCount = 1;
        }
        if (itemCount != remainInven + 1)
        {
            allPrice = Go.GetComponent<ItemSC>().itemData.purchasePrice * itemCount;
            number.text = itemCount.ToString();
            price.text = Go.GetComponent<ItemSC>().itemData.itemName + " : " + allPrice.ToString("#,##0") + "$";
        }
    }
}
