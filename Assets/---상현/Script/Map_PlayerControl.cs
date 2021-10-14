using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_PlayerControl : MonoBehaviour
{
    public DiceControlManager dCM;

    public GameObject diceBtn;
    public int diceNum;

    //bool canMove = false;

    public List<GameObject> tiles = new List<GameObject>();
    private Stack<Node> stack = new Stack<Node>();


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
    }
    // Update is called once per frame
    void Update()
    {
        if (Map_DataManager.isCanMove == true)
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            if (!Input.anyKeyDown) return;

            if (Physics.Raycast(this.transform.position, Vector3.down, out var hit, 10f, NodeManager.Instance.whatIsNode))
            {
                var node = hit.transform.GetComponent<Node>();
                var nextNode = GetDirectionToNode(node, new Vector2(horizontal, vertical));

                if (node == null) return;

                if (nextNode)
                {
                    this.transform.position = nextNode.transform.position + Vector3.up * 5f;
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

                    //moveCount.text = "MoveCount : " + diceNum.ToString();

                    if (Map_DataManager.diceCountSum == 0)
                    {
                        RemoveList();
                        nextNode.events.Invoke();
                        dCM.DiceActive(false);

                        Map_DataManager.isCanMove = false;

                        Map_DataManager.diceCount[0] = 0;
                        Map_DataManager.diceCount[1] = 0;

                        DiceControlManager.isRolled = false;
                        DiceControlManager.diceChecked = false;
                        //Debug.Log(nextNode);
                        
                    }
                }
            }
        }
    }

    private Node GetDirectionToNode(Node node, Vector2 dir)
    {
        if (dir.x > 0f) return node.right;
        if (dir.x < 0f) return node.left;
        if (dir.y > 0f) return node.up;
        if (dir.y < 0f) return node.down;

        return null;
    }

    public void DiceStackClear()
    {
        stack.Clear();
        System_MainDataManager.mainData.nodeData.Clear();
    }

}
