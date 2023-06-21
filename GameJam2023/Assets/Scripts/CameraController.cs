using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, moveScalar, rotateSpeed;
    private Vector3 moveDir;
    private Vector3 lastMousePos;
    Vector3 mouseDelta = new();

    [SerializeField] Vector2 yMouseAxisClamp;

    [SerializeField] Vector2 yPosLimit;

    void Update()
    {
        moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDir += transform.forward * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.S))
            moveDir += -transform.forward * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.A))
            moveDir += -transform.right * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.D))
            moveDir += transform.right * Time.deltaTime * moveSpeed;

        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.LeftControl))
            moveDir += Vector3.up * Time.deltaTime * moveSpeed * 0.8f;
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Space))
            moveDir += Vector3.down * Time.deltaTime * moveSpeed * 0.8f;



        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += moveDir * moveScalar;
        else
            transform.position += moveDir;

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, yPosLimit.x, yPosLimit.y), transform.position.z);
        
        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;


            mouseDelta.x -= Input.GetAxis("Mouse X");
            mouseDelta.y += Input.GetAxis("Mouse Y");
            mouseDelta.y = Mathf.Clamp(mouseDelta.y,yMouseAxisClamp.x,yMouseAxisClamp.y);


            transform.rotation = Quaternion.Euler(mouseDelta.y,-mouseDelta.x, 0f);

            //if (lastMousePos.x >= 0 && lastMousePos.y >= 0)
            //{
            //mouseDelta = Input.mousePosition - lastMousePos;
            //mouseDelta = new Vector3(-mouseDelta.y * rotateSpeed, mouseDelta.x * rotateSpeed, 0);
            //mouseDelta = new Vector3(transform.eulerAngles.x + mouseDelta.x, transform.eulerAngles.y + mouseDelta.y, 0);
            //}
            //lastMousePos = Input.mousePosition;
        }
        else
        {
            lastMousePos = new Vector3(-1, -1, -1);
            Cursor.visible = true;
        }
    }
}
