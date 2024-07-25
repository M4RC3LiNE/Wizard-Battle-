using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject sphere;
    public float speed = 1.0f;
    public float maxSize = 50;
    void Update()
    {
        if (sphere.activeInHierarchy)
        {
            if (sphere.transform.localScale.x < maxSize)
            {
                sphere.transform.localScale += new Vector3(Time.deltaTime * speed, Time.deltaTime * speed, Time.deltaTime * speed);
            }
            else{
                sphere.SetActive(false);
                Destroy(this);
            }
        }
    }
}
