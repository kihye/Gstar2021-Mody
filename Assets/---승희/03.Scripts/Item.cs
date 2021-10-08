using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]        //Assets > 우클릭 > New Item 클릭 > item 클릭
public class Item : ScriptableObject
{
    public string itemName;         //아이템 이름
    public ItemType itemType;       //아이템 타입 (분류)
    public Sprite itemSprite;       //아이템 스프라이트 (이미지)

    public int purchasePrice;       //구매 가격
    public int sellPrice;           //판매 가격

    public enum ItemType
    {
        Cash,    //환금용
        Healing, //소비용 (회복)
        Buff,    //소비용 (버프)
        Debuff,  //소비용 (디버프)
        belong   //소지용
    }

    public enum ItemRarity
    {
        Common,     //일반
        Rare,       //희귀
        Unique      //영웅
    }

}
