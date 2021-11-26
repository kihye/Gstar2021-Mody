using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class DiceRotate : MonoBehaviour
{   
    public TextMesh[] diceNumTxt;
    public GameObject diceEff;
    public Transform playerTr;

    private Vector3 rot;  
    private string s;
    private int tInt;
    private int diceNum;

    public static bool isTurnOn;
    /// <summary>
    /// Map_playerControl.cs 에 public GameObject dive 해서 주사위 받아오고 집어 넣주고
    /* Map_playerControl.cs 에 Update문 첫줄에 복사
     
    if(Input.GetKeyDown(KeyCode.Space) && Map_DataManager.isCanMove == false)
        {
            dice.SetActive(true);
            DiceRotate.isTurnOn = true;
        }

     */
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (isTurnOn)
        {
            var currentPosition = new Vector3(playerTr.position.x, playerTr.position.y + 45, playerTr.position.z);
            this.transform.position = currentPosition;
            rot = new Vector3(Time.time * 360f, Time.time * 360f);

            this.transform.rotation = Quaternion.Euler(rot);

            for (int i = 0; i < diceNumTxt.Length; i++)
            {
                tInt = int.Parse(diceNumTxt[i].text);
                tInt++;
                s = tInt.ToString();
                diceNumTxt[i].text = s;
            }
            if (tInt > 6)
            {
                for (int i = 0; i < diceNumTxt.Length; i++)
                {
                    tInt = int.Parse(diceNumTxt[i].text);
                    tInt = 1;
                    s = tInt.ToString();
                    diceNumTxt[i].text = s;
                }
            }
        }        
        if (Input.GetKeyDown(KeyCode.Space) && isTurnOn == true)
        {
            isTurnOn = false;
            this.transform.rotation = Quaternion.Euler(0, playerTr.transform.rotation.eulerAngles.y + 45, 0);
            DelayDiceMove(0.5f, 5f);
            diceNum = int.Parse(this.transform.GetChild(0).GetComponent<TextMesh>().text);
            Map_DataManager.isCanMove = true;
            Map_DataManager.diceCountSum = diceNum;
            //Debug.Log(diceNum);

        }
    }

    private async void DelayDiceMove(float time, float bounceDistance = 1f)
    {
        const int delayMilliSecond = 20;
        var milliSecondTime = time * 1000f * Time.timeScale;
        var elapsedTime = 0f;
        //var currentPosition = this.transform.position;
        var currentPosition = new Vector3(playerTr.position.x, playerTr.position.y + 45, playerTr.position.z);
        while (elapsedTime < milliSecondTime)
        {
            elapsedTime += delayMilliSecond;          

            this.transform.position = currentPosition +Vector3.up * Mathf.Sin(elapsedTime / milliSecondTime * Mathf.PI) * bounceDistance;

            await Task.Delay(delayMilliSecond);
        }

        this.transform.position = currentPosition;
        Instantiate(diceEff,currentPosition,Quaternion.identity);       
        this.gameObject.SetActive(false);       
        
    }

}
