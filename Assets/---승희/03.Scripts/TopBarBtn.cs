using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarBtn : MonoBehaviour
{
    private Text txt;
    public void TextColorChange()
    {
        txt = this.GetComponentInChildren<Text>();

        txt.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    }

    public void TextColorReset()
    {
        txt = this.GetComponentInChildren<Text>();

        txt.color = new Color(186 / 255f, 186 / 255f, 186 / 255f);
    }
}
