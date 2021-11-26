using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform playerTr;
   
    public float turnSpeed = 4.0f;
    private float moveSpeed = 30.0f;
    private float xRotate = 0.0f;
    private Vector3 pastPos;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            
            MouseRotation();
            CameraMove();
        }
        if(Input.GetMouseButtonUp(1))
        {            
            ResetCamera();
        }
    }
    void ResetCamera()
    {        
        this.transform.eulerAngles = new Vector3(25, playerTr.eulerAngles.y-45, 0);
    }
    void CameraMove()
    {
        Vector3 move =
            transform.forward * Input.GetAxis("Vertical") +
            transform.right * Input.GetAxis("Horizontal");

       
        transform.position += move * moveSpeed * Time.deltaTime;
    }
    void MouseRotation()
    {

        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;

        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
}
