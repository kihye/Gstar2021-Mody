using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]        //Assets > 우클릭 > New Item 클릭 > item 클릭
public class Item : ScriptableObject
{
    public int itemNum;             //아이템 번호
    public string itemName;         //아이템 이름
    public ItemType itemType;       //아이템 타입 (분류)
    public BuffType buffType;
    public ItemRarity itemRarity;   //아이템 등급 (분류)
    public Sprite itemSprite;       //아이템 스프라이트 (이미지)

    public int dataNum;               // 사용 아이템에 들어갈 수치
    public int dataTurn;               // 사용 아이템에 들어갈 턴 수치

    public int purchasePrice;       //구매 가격
    public int sellPrice;           //판매 가격

    private string _itemInfo;
    public string iteminfo
    {
        get
        {
            return _itemInfo;
        }
        set
        {
            if(itemNum > 100 && itemNum < 200)
            {
                _itemInfo = "체력을 즉시 " + dataNum + "만큼 회복합니다.\n";
            }
            else if (itemNum > 200 && itemNum < 300)
            {
                _itemInfo = "방어력을 " + dataTurn + "턴간 " + dataNum + " 증가시킵니다.\n";
            }
            else if (itemNum > 300 && itemNum < 400)
            {
                _itemInfo = "공격력을 " + dataTurn + "턴간 " + dataNum + " 증가시킵니다.\n";
            }
        }
    }
    public enum ItemType
    {
        Cash,    //환금용
        Healing, //소비용 (회복)
        Buff,    //소비용 (버프)
        Debuff,  //소비용 (디버프)
        Belong   //소지용
    }

    public enum BuffType
    {
        None,
        Atk,
        Def
    }

    public enum ItemRarity
    {
        Common,     //일반
        Rare,       //희귀
        Unique      //영웅
    }
}