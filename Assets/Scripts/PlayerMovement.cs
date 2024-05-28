using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;

    private float jumpHeight = 100f;

    float horizontalInput, verticalInput;

    Vector3 moveDirec;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        KeyInput();

        SpeedControl();

        isgrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (isgrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void KeyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //if (Input.GetKey("Jump") && isgrounded)
        {
            //rb.AddForce(Vector3.up * jumpHeight, ForceMode.Force);
        }
    }

    void MovePlayer()
    {
        moveDirec = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirec.normalized * moveSpeed * 10f, ForceMode.Force);
    }


    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    [Header("Drag")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isgrounded;
    public float groundDrag;
}
