using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCam : MonoBehaviour
{
    public Transform camLoc;
    public float sensX, sensY = 10;
    float xRotation, yRotation;
    public Transform orientation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public GameObject orbView;
    private void Update()
    {
        if (!orbView.activeInHierarchy)
        {
            transform.position = camLoc.position;

            var mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            var mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
