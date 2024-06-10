using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelRotation : MonoBehaviour
{
    public Transform orientation;

    void Update()
    {
        this.transform.rotation = orientation.rotation;
    }
}
