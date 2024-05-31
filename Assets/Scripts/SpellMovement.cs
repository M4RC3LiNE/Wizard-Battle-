using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var moveDirec = transform.forward;
        rb.AddForce(moveDirec.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
