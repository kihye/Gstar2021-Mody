using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_PlayerControl : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject dice;

    public DiceControlManager dCM;

    public GameObject diceZone;
    public int diceNum;

    private bool turnOver = false;

    public List<GameObject> tiles = new List<GameObject>();
    private Stack<Node> stack = new Stack<Node>();
    private RaycastHit hit;

    public void RemoveList()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles.Remove(tiles[i]);
        }
    }
    private void Awake()
    {
        System_MainDataManager.mainData.playerTransform = this.transform;
        this.transform.position = System_MainDataManager.mainData.playerPos;
        mainCam.transform.position = new Vector3(transform.position.x, transform.position.y + 85, transform.position.z - 90);
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Map_DataManager.isCanMove == false)
        {
            dice.SetActive(true);
            DiceRotate.isTurnOn = true;
        }
        diceZone.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 14, this.transform.position.z);
        if (Map_DataManager.isCanMove == true)
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            if (!Input.anyKeyDown) return;

            if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 100f, NodeManager.Instance.whatIsNode))
            {
                if (Input.GetKeyDown(KeyCode.D))//왼쪽
                {
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y+90, 0);                 

                }              
                if (Input.GetKeyDown(KeyCode.A))//오른쪽
                {
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y - 90, 0);                 
                }

                //DiceRotate.isRolled = true;
                
                dCM.DiceActive(false);

                if (Input.GetKeyDown(KeyCode.W))
                {
                    Map_DataManager.isMoving = true;
                    var node = hit.transform.GetComponent<Node>();
                    var pRotate = PlayerRotate(this.transform);
                    var nextNode = GetDirectionToNode(node, new Vector2(horizontal, vertical), pRotate);

                    if (node == null)
                    {
                        Debug.Log("No way");
                        return;
                    }

                    if (nextNode)
                    {
                        //Debug.Log(nextNode);
                        this.transform.position = nextNode.transform.position + Vector3.up * 15f;
                        System_MainDataManager.mainData.playerPos = this.transform.position;

                       
                        if (stack.Count == 0 || nextNode != stack.Peek())
                        {
                            Map_DataManager.diceCountSum--;

                            stack.Push(node);
                            System_MainDataManager.mainData.nodeData.Push(node);
                        }
                        else
                        {
                            stack.Pop();
                            System_MainDataManager.mainData.nodeData.Pop();

                            Map_DataManager.diceCountSum++;
                        }

                        if (Map_DataManager.diceCountSum == 0)
                        {
                            RemoveList();
                            nextNode.events.Invoke();

                            Map_DataManager.isCanMove = false;
                            Map_DataManager.isMoving = false;

                            Map_DataManager.diceCount[0] = 0;
                            Map_DataManager.diceCount[1] = 0;

                            //DiceRotate.isRolled = false;
                            //DiceRotate.stop = false;

                            DiceControlManager.isRolled = false;
                            DiceControlManager.diceChecked = false;
                            DiceControlManager.isMoved = false;

                            System_MainDataManager.mainData.playerTurn++;
                            stack.Clear();
                        }
                    }
                    else
                    {
                        Debug.Log("ERROR");
                    }
                }
            }
        }
    }
    private float PlayerRotate(Transform tr)
    {
        float playerR = tr.eulerAngles.y;       
        return playerR;
    }
    private bool FloatCheck(float checkAngle, float f)
    {
        if (f <= checkAngle + 1 && f >= checkAngle - 1)
            return true;

        return false;
    }
    private Node GetDirectionToNode(Node node, Vector2 dir,float f)
    {
        //Debug.Log(f);
        if(FloatCheck(315f, f))
        {
            if (dir.y > 0f) return node.left;
        }
        else if(FloatCheck(225f, f))
        {
            if (dir.y > 0f) return node.down;
        }       
        else if(FloatCheck(135f, f))
        {
            if (dir.y > 0f) return node.right;
        }
        else if(FloatCheck(45f, f))
        {
            return node.up;
        }

        return null;
    }

    public void DiceStackClear()
    {
        stack.Clear();
        System_MainDataManager.mainData.nodeData.Clear();
    }

}
