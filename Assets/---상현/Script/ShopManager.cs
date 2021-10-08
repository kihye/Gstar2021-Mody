using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using System.Text.RegularExpressions;
public class ShopManager : MonoBehaviour
{   

    public GameObject buyItem;
    public Text number;
    public Text price;
    public Image curImage;

    private Sprite buyImage;
    private int num;
    private int allPrice;
    private string itemPrice;

    private void Start()
    {
        num = int.Parse(number.text);
       
    }

    public void ChangeItemInfo()
    {
        buyImage = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
        curImage.sprite = buyImage;

        price.text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        itemPrice = Regex.Replace(price.text, @"\D", "");
      
      
        
        num = 1;
        number.text = num.ToString();
    }
        
    public void Stroe()
    {
        this.gameObject.SetActive(true);
    }
    public void ClickItem()
    {
        buyItem.SetActive(true);
    }
    public void ClickCancleBtn()
    {
        buyItem.SetActive(false);
    }
    public void ClickBuyBtn()
    {
        buyItem.SetActive(false);
    }
    public void ClickLeftBtn()
    {
       
        if (num > 1)
        {
            num--;
            allPrice -= int.Parse(itemPrice);
            number.text = num.ToString();
            price.text = "$" + allPrice.ToString("#,##0");

        }
    }
    public void ClickRightBtn()
    {      
        if(num!=99)
        {
            num++;           
            allPrice = int.Parse(itemPrice) * num;
            number.text = num.ToString();
            price.text = "$"+allPrice.ToString("#,##0");
            
        }
    }

}
