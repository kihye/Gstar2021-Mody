using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceControlManager : MonoBehaviour
{
    public Map_DataManager m_DM;
    public Map_PlayerControl m_PC;

    public GameObject[] moveDice = new GameObject[2];
    public Rigidbody[] diceRigid = new Rigidbody[2];

    public static Vector3[] diceVelocity = new Vector3[2];
    public Vector3 startSpot;

    public float diceSpeed;

    public static bool isRolled = false;
    public static bool diceChecked = false;

    private void Awake()
    {
        DiceActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if ((!moveDice[0].activeSelf) && (!moveDice[1].activeSelf))
            {
                m_PC.DiceStackClear();
                DiceActive(true);
                RollDice(moveDice);
                isRolled = true;
            }
        }
        if(Map_DataManager.myDiceCount == 1)
        {
            if (moveDice[0].activeSelf) 
            {
                diceVelocity[0] = diceRigid[0].velocity;
            }
        }
        else if(Map_DataManager.myDiceCount == 2)
        {
            if (moveDice[0].activeSelf && moveDice[1].activeSelf)
            {
                diceVelocity[0] = diceRigid[0].velocity;
                diceVelocity[1] = diceRigid[1].velocity;
            }
        }
    }
    public void DiceActive(bool isActive)
    {
        if(!isActive)
        {
            for (int i = 0; i < 2; i++)
                moveDice[i].SetActive(isActive);
        }
        else
        {
            for (int i = 0; i < Map_DataManager.myDiceCount; i++)
                moveDice[i].SetActive(isActive);
        }
    }
    private void RollDice(GameObject[] dices)
    {
        for(int i = 0; i < Map_DataManager.myDiceCount; i++)
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);


            moveDice[i].transform.position = startSpot;

            transform.rotation = Quaternion.identity;
            diceRigid[i].AddForce(transform.up * diceSpeed);
            diceRigid[i].AddTorque(dirX, dirY, dirZ);
        }
    }
}
