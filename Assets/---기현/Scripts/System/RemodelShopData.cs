using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemodelShopData : MonoBehaviour
{
    public static RemodelShopData instance;
    public bool iqm = true;
    public bool em = true;
    public bool hm = true;

    public int ih = 2;
    public int mf = 2;
    public int mm = 3;
    public int ps = 3;

    public int qc = 2;
    public int hde = 2;
    public int tc = 3;
    public int ihs = 3;

    public bool w = true;

    public bool rs = true;

    public int newPocket = 3;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }
    }
    public void InitializeData()
    {
        iqm = true;
        em = true;
        hm = true;

        ih = 2;
        mf = 2;
        mm = 3;
        ps = 3;

        qc = 2;
        hde = 2;
        tc = 3;
        ihs = 3;

        w = true;

        rs = true;

        newPocket = 3;
    }
}
