using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitStill : MonoBehaviour
{
    private Vector3 pos;
    void Start()
    {
        pos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = pos;
    }
}
