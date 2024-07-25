using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltHolder : MonoBehaviour
{
    [System.NonSerialized]public SpellItem spell;
    public GameObject currentOrb;
    bool readyToDie = false;
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<SpellMovement>())
            {
                transform.GetChild(i).GetComponent<SpellMovement>().currentOrb = currentOrb;
            }
        }
        if (transform.childCount > 0)
        {
            readyToDie = true;
        }
        else if (readyToDie == true)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void ObjectHit()
    {
        if (spell.destroyOnTrigger)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            Destroy(this.gameObject);
        }
        
    }
}
