using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    private float checkTime = 0f; 

    private void Update()
    {
        checkTime += Time.deltaTime;
        if(checkTime > 2f)
        {
            Destroy(gameObject);
        }
    }
}
