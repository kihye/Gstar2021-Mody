using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropActive : MonoBehaviour
{
    [SerializeField]
    public List<Item> items = new List<Item>();

    public Item selectedItem;
    public Image DropItem;

    private bool isRolled = false;
    public void RollDrop()
    {
        if(!isRolled)
        {
            int Rarityroll = Random.Range(0, 100);
            int roll = Random.Range(0, 2);
            if (Rarityroll <= 75)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (items[i].itemRarity == Item.ItemRarity.Common)
                    {
                        if (items[i].itemNum == roll)
                        {
                            DropItem.sprite = items[i].itemSprite;
                            selectedItem = items[i];
                            break;
                        }
                    }
                }
            }
            else if ((Rarityroll > 75) && (Rarityroll <= 95))
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (items[i].itemRarity == Item.ItemRarity.Rare)
                    {
                        if (items[i].itemNum == roll)
                        {
                            DropItem.sprite = items[i].itemSprite;
                            selectedItem = items[i];
                            break;
                        }
                    }
                }
            }
            else if ((Rarityroll < 95) && Rarityroll <= 100)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (items[i].itemRarity == Item.ItemRarity.Unique)
                    {
                        if (items[i].itemNum == roll)
                        {
                            DropItem.sprite = items[i].itemSprite;
                            selectedItem = items[i];
                            break;
                        }
                    }
                }
            }
        }

        isRolled = true;
    }
}
