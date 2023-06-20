using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed, moveScalar, rotateSpeed;
    private Vector3 moveDir;
    private Vector3 lastMousePos;

    void Update()
    {
        moveDir = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
            moveDir += transform.forward * Time.deltaTime * moveSpeed;
        if(Input.GetKey(KeyCode.S))
            moveDir += -transform.forward * Time.deltaTime * moveSpeed;
        if(Input.GetKey(KeyCode.A))
            moveDir += -transform.right * Time.deltaTime * moveSpeed;
        if(Input.GetKey(KeyCode.D))
            moveDir += transform.right * Time.deltaTime * moveSpeed;

        if (Input.GetKey(KeyCode.E))
            moveDir += Vector3.up * Time.deltaTime * moveSpeed * 0.8f;
        if (Input.GetKey(KeyCode.Q))
            moveDir += Vector3.down * Time.deltaTime * moveSpeed * 0.8f;

        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += moveDir * moveScalar;
        else
            transform.position += moveDir;

        if (Input.GetMouseButton(2)) 
        {
            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Vector3 mouseDelta;
            if (lastMousePos.x >= 0 && lastMousePos.y >= 0)
            {
                mouseDelta = Input.mousePosition - lastMousePos;
                mouseDelta = new Vector3(-mouseDelta.y * rotateSpeed, mouseDelta.x * rotateSpeed, 0);
                mouseDelta = new Vector3(transform.eulerAngles.x + mouseDelta.x, transform.eulerAngles.y + mouseDelta.y, 0);
                transform.eulerAngles = mouseDelta;
            }
            lastMousePos = Input.mousePosition;
        }
        else
        {
            lastMousePos = new Vector3(-1, -1, -1);
            Cursor.visible = true;
        }
    }
}
