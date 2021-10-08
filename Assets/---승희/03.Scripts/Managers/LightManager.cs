using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager dLight;

    void Awake()
    {
        if (dLight == null)
        {
            dLight = this;
            DontDestroyOnLoad(dLight);
        }
        else
        {
            Destroy(dLight);
        }
    }

    public void SetShadowOption(int num)
    {
        switch (num)
        {
            case 0:
                dLight.GetComponent<Light>().shadows = LightShadows.None;
                break;
            case 1:
                dLight.GetComponent<Light>().shadows = LightShadows.Soft;
                break;
            case 2:
                dLight.GetComponent<Light>().shadows = LightShadows.Hard;
                break;
        }
    }
}
