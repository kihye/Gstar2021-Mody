using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour
{
    public enum NodeType { Normal, Battle, Hospital, Remodel, Shop};

    public NodeType nodeType;
    public UnityEvent events;
    
    public Node up, right, left, down;

    private Renderer nodeColor;

    public void Awake()
    {
        nodeColor = gameObject.GetComponent<Renderer>();
        switch(nodeType)
        {
            case NodeType.Normal:
                nodeColor.material.color = Color.gray;
                break;
            case NodeType.Battle:
                nodeColor.material.color = Color.red;
                break;
            case NodeType.Hospital:
                nodeColor.material.color = Color.green;
                break;
            case NodeType.Remodel:
                nodeColor.material.color = Color.cyan;
                break;
            case NodeType.Shop:
                nodeColor.material.color = Color.yellow;
                break;
        }
        
    }
    public void Battle()
    {
        Debug.Log("전투 발판입니다");
    }
   
    public void Hospital()
    {
        Debug.Log("치료소 발판입니다");
    }
    public void Remodel()
    {
        Debug.Log("개조 발판입니다");
    }
}

