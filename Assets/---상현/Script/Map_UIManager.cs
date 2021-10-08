using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_UIManager : MonoBehaviour
{

    public Text diceCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diceCountText.text = "MoveCount : " + CalDiceCount();
    }
    private int CalDiceCount()
    {
        if(Map_DataManager.isCanMove)
            return Map_DataManager.diceCountSum;

        return 0;
    }
}
