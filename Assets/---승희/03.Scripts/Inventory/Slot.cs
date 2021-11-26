using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public Item item;
    public Sprite image;
    public static bool isSell = false;
    public static int sellPrice;

    private Button button;
    //private int itemCount;
    [SerializeField]
    private bool isClicked = false;

    private void Awake()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ItemClickPopup);
    }

    public void AddItem(Item _item, int _itemCount = 1)      //slot에 아이템 추가
    {

        item = _item;
        this.GetComponent<Image>().sprite = _item.itemSprite;
        //itemCount = _itemCount;

        SetColorAlpha(1);                                   //아이템 이미지(스프라이트)의 투명도를 1(255)로 설정
    }                                                       //최소 0 ~ 최대 1

    public void ItemClickPopup()
    {
        if(!System_MainDataManager.mainData.isBattleScene)
        {
            if (item != null)
            {
                isClicked = true;
                UIManager.instance.SetPopup
                                            (
                                                "[" + this.item.itemName + "]\n아이템을 파시겠습니까?\n"
                                                + "판매 가격 : " + System_MainDataManager.mainData.MoneyText(item.sellPrice) + "$",
                                                "예",
                                                "아니오",
                                                () => { SellItem(); },
                                                () => { DontSellitem(); }
                                            );
            }
            else if (item == null)
            {
                Debug.Log("아이템이 존재하지 않음.");
                return;
            }
        }
        else
        {
            if (item != null)
            {
                if (item.itemType != Item.ItemType.Cash || item.itemType != Item.ItemType.Belong)
                {
                    isClicked = true;
                    UIManager.instance.SetPopup
                                                (
                                                    "[" + this.item.itemName + "]\n" + item.iteminfo +
                                                    "\n\n아이템을 사용하시겠습니까?",
                                                    "예",
                                                    "아니오",
                                                    () => { UseItem(); },
                                                    () => { DontSellitem(); }
                                                );
                }
            }
            else if (item == null)
            {
                Debug.Log("아이템이 존재하지 않음.");
                return;
            }
            
        }
    }
        
    private void DontSellitem()
    {
        isClicked = false;
    }
    private void SellItem()
    {

        //itemCount -= _useCount;

        if (isClicked)
        {

            sellPrice = item.sellPrice;
            ClearSlot();
            isClicked = false;
            isSell = true;
        }

    }
    private void SetColorAlpha(float _alpha)
    {
        Color color = this.GetComponent<Image>().color;
        color.a = _alpha;
        this.GetComponent<Image>().color = color;
    }

    private void UseItem()
    {
        //Debug.Log(item.itemName + " 사용");
        //itemCount -= _useCount;
        if (isClicked)
        {
            GameObject.Find("BattleManager").GetComponent<ItemUseChecker>().ApplyItem(item);
            ClearSlot();
            isClicked = false;
        }
    }

    private void ClearSlot()
    {
        item = null;
        this.GetComponent<Image>().sprite = image;
        //itemCount = 0;

        SetColorAlpha(1);
    }
}