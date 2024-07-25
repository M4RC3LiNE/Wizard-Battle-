using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpellMovement : MonoBehaviour
{
    [NonSerialized]public SpellItem spell;
    [NonSerialized]public float moveSpeed = 5.0f;
    [NonSerialized]public float range = 100;
    [NonSerialized]public float drag;
    public Vector3 initialPos;
    

    private bool explosive;
    private GameObject explosion;

    void Start()
    {
        var pos = transform.position;
        initialPos = new Vector3(pos.x, pos.y, pos.z);
    }

    void Update()
    {
        //Perks
        if (currentOrb)
        {
            var orbItem = currentOrb.GetComponent<OrbItem>();
            perk.Clear();
            for (int i = 0; i < orbItem.perk.Count; i++)
            {
                perk.Add(orbItem.perk[i]);
            }
        }


        if (spell)
        {
            //Perk Calcs    
            float perkSpeed = 0;
            float perkRange = 0;
            float perkDrag = 0;
            explosive = false;
            for (int i = 0; i < perk.Count; i++)
            {
                perkSpeed += perk[i].speed;
                perkRange += perk[i].range;
                perkDrag += perk[i].drag;
                if (perk[i].ability == Perk.perk.Explosive)
                {
                    explosive = true;
                    explosion = perk[i].explosion;
                }
            }

            moveSpeed = spell.speed + perkSpeed;
            range = spell.range + perkRange;
            if (!spell.bolt)
            {
                drag = spell.drag + perkDrag;
            }
            else{
                drag = spell.boltDrag + perkDrag;
            }
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        transform.Rotate(Vector3.right * drag * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, initialPos) >= range)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.transform.parent.GetComponent<BoltHolder>() && !other.GetComponent<SpellMovement>() && !other.GetComponent<PlayerMovement>())
        {
            this.transform.parent.gameObject.GetComponent<BoltHolder>().ObjectHit();
        }
        if (other.gameObject != GameObject.Find("Player"))
        {
            if (explosive)
            {
                if (explosion)
                {
                    var newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
                    
                    Destroy(this);
                }
            }
        }
    }


    //Perks
    public GameObject currentOrb;
    public List<Perk> perk = new List<Perk>();

    
}
