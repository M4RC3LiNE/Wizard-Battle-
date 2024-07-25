using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [System.NonSerialized]public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (player && !other.GetComponent<PlayerMovement>() && !other.GetComponent<SpellMovement>())
        {
            Debug.Log(other.transform.position);
            player.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        
    }
}
