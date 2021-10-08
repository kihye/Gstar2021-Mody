using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private static string playerName;

    public static string getsetName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }
}
