using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSC : MonoBehaviour
{
    [SerializeField] private ShopManager shop;

    [SerializeField] private GameObject toolTip;
    [SerializeField] private Text toolTipText;

    private Image img;
    private Text itemInfo;

    [SerializeField]
    private Button button;
    // texts[0] == 아이템 이름, texts[1] == 아이템 가격
    public Item itemData;
    private void Start()
    {
        //if(ShopManager.slotNum == 0)

        img = GetComponent<Image>();
        button = GetComponent<Button>();
        shop = GetComponentInParent<ShopManager>();
        itemInfo = gameObject.GetComponentInChildren<Text>();

        button.onClick.AddListener(()=> { shop.ClickItem(); });
        button.onClick.AddListener(shop.ChangeItemInfo);
    }
    private void Update()
    {
        img.sprite = itemData.itemSprite;
        itemInfo.text = itemData.itemName + " : " + 
            System_MainDataManager.mainData.MoneyText(itemData.purchasePrice) + "$";
        toolTipText.text = ToolTipText();
    }
    public string ToolTipText()
    {
        string str = "[" + itemData.itemName + "]\n";
        itemData.iteminfo = "";
        str += itemData.iteminfo;
        //str += "판매 가격 : " + System_MainDataManager.mainData.MoneyText(itemData.sellPrice) + "$";
        return str;
    }
}
