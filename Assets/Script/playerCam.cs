using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public Transform player;

    public Camera cam;

    private float mouseX, mouseY;

    public float mouseSensitivity;

    public float xRotation;



    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);
            
        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        if (Input.GetKeyDown(KeyCode.V))
        {
            Vector3 camPos = cam.transform.localPosition;
            camPos.z -= 2;
            cam.transform.localPosition = camPos;
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            Vector3 camPos = cam.transform.localPosition;
            camPos.z += 2;
            cam.transform.localPosition = camPos;
        }





    }
}
