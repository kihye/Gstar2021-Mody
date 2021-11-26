using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : MonoBehaviour
{
    [SerializeField] private Text pName;
    [SerializeField] private Text pHp;
    [SerializeField] private Text pAtk;
    [SerializeField] private Text pDef;
    // Update is called once per frame
    void Update()
    {
        pName.text = "이름 : " + System_MainDataManager.mainData.name;
        pHp.text = System_MainDataManager.mainData.curHp + " / " + System_MainDataManager.mainData.maxHp;
        pAtk.text = System_MainDataManager.mainData.atkPoint.ToString();
        pDef.text = System_MainDataManager.mainData.defPoint.ToString();
    }
}
