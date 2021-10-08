using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Button button;

    public Item item;
    public Image image;
    int itemCount;

    private void Awake()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ItemClickPopup);
    }

    public void AddItem(Item _item, int _itemCount = 1)     //slot에 아이템 추가
    {
        item = _item;
        image.sprite = _item.itemSprite;
        itemCount = _itemCount;

        SetColorAlpha(1);                                   //아이템 이미지(스프라이트)의 투명도를 1(255)로 설정
    }                                                       //최소 0 ~ 최대 1

    public void ItemClickPopup()
    {
        if (this.item != null)
        {
            UIManager.instance.SetPopup
                                        (
                                            this.item.itemName + "\n아이템을 사용하시겠습니까?",
                                            "예",
                                            "아니오",
                                            () => { UseItem(1); },
                                            () => { }
                                        );
        }
        else if (this.item == null)
        {
            Debug.Log("아이템이 존재하지 않음.");
            return;
        }
    }


    private void SetColorAlpha(float _alpha)
    {
        Color color = image.color;
        color.a = _alpha;
        image.color = color;
    }

    private void UseItem(int _useCount)
    {
        itemCount -= _useCount;

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    private void ClearSlot()
    {
        item = null;
        image.sprite = null;
        itemCount = 0;

        SetColorAlpha(0);
    }
}
