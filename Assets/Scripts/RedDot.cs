using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RedDot : MonoBehaviour
{
    public Transform cam;

    public bool renderSphere;


    void Update()
    {
        if (renderSphere)
        {
            var dist = Vector3.Distance(cam.position, transform.position);
            transform.localScale = new Vector3(dist, dist, dist) * 0.05f;
            GetComponent<MeshRenderer>().enabled = true;
        }
        else{
            GetComponent<MeshRenderer>().enabled = false;
        }

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 100000))
        {
            transform.position = hit.point;
        }
        else{
            Ray ray = new Ray(cam.position, cam.forward);
            transform.position = ray.GetPoint(50);
        }
    }
}
