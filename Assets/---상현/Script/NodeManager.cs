using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : Singleton<NodeManager>
{
    public LayerMask whatIsNode;

    [SerializeField]
    private List<Node> nodes = new List<Node>();

    [SerializeField]
    private float detectRange = 40f;

    private void Start()
    {
        foreach (var node in nodes) //노드검사
        {
            var currentNodePos = node.transform.position;
            var nearColliders = Physics.OverlapSphere(currentNodePos, detectRange, whatIsNode); //주변 반경40만큼whatIsNode가 있는 콜리더 검사

            foreach (var nearCollider in nearColliders) {                                       //주변 노드 콜리더 검사
                var dir = nearCollider.transform.position - currentNodePos;
                var leftRightCheck = Vector3.Dot(Vector3.right, dir.normalized);                
                var upDownCheck = Vector3.Dot(Vector3.forward, dir.normalized);
                var nearNode = nearCollider.GetComponent<Node>();

                if (leftRightCheck > 0) node.right = nearNode;
                if (leftRightCheck < 0) node.left = nearNode;
                if (upDownCheck > 0) node.up = nearNode;
                if (upDownCheck < 0) node.down = nearNode;
              
            }
        }
    }
}
