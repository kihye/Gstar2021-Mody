using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortMeshRenderer : MonoBehaviour
{
    MeshRenderer mesh;
    public string sortingLayerName;
    public int sortingOrder;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.sortingLayerName = sortingLayerName;
        mesh.sortingOrder = sortingOrder;
    }
    private void Update()
    {
        mesh.sortingLayerName = sortingLayerName;
        mesh.sortingOrder = sortingOrder;
    }
}
