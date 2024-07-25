using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier = 10;
    bool readyToJump = true;

    float horizontalInput, verticalInput;

    Vector3 moveDirec;

    Rigidbody rb;

    CharacterController cc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerHeight = this.GetComponent<BoxCollider>().size.y;
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (cc.isGrounded)
        {
            Debug.Log("grounded");
        }

        KeyInput();

        SpeedControl();

        //isgrounded = Physics.Raycast(GetComponent<BoxCollider>().center, Vector3.down, (playerHeight * 0.5f) + 0.0f, whatIsGround);

        if (cc.isGrounded)
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

        if (Input.GetKey(KeyCode.Space) && cc.isGrounded && readyToJump)
        {
            Debug.Log("Jump");
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void MovePlayer()
    {
        moveDirec = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isgrounded)
            rb.AddForce(moveDirec.normalized * moveSpeed * 10f, ForceMode.Force);
        else
            rb.AddForce(moveDirec.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
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

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    [Header("Drag")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool isgrounded;
    public float groundDrag = 2;
}
