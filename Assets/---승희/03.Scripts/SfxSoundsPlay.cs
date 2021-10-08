using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxSoundsPlay : MonoBehaviour
{
    public void Sfx_Click()
    {
        SoundManager.instance.PlaySFX("Click");
    }

    public void Sfx_Water()
    {
        SoundManager.instance.PlaySFX("Water");
    }
}
