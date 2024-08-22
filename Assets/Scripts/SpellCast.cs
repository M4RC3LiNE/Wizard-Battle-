using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public GameObject cooldownMeter;
    public Transform spellCastLoc;
    public Transform cam;
    public Transform projectiles; //Parent of all projectile objects
    public Transform dot;

    OrbItem currentOrb;
    OrbInv orbInv;
    int selectedSlot;
    CooldownMeter meter;

    void Start()
    {
        orbInv = GetComponent<OrbInv>();

        meter = cooldownMeter.GetComponent<CooldownMeter>();
    }


    float TotalCooldown(OrbItem orb)
    {
        UpdateCurrentOrb();
        float total = 0f;
        for (int i = 0; i < currentOrb.spell.Count; i++)
        {
            total += currentOrb.spell[i].cooldown;
        }
        return total;
    }

    bool readyToFire;
    Coroutine coroutine;
    void Update()
    {
        UpdateCurrentOrb();

        bool invOpen = GetComponent<OrbInv>().orbView.activeInHierarchy;
        readyToFire = !invOpen && meter.cd <= 0;
        
        //firing
        if (Input.GetMouseButton(0) && readyToFire)
        {
            var orbInv = GetComponent<OrbInv>();
            var selectedOrb = GetComponent<OrbSelect>().selectedSlot;
            var orbItem = orbInv.orb[selectedOrb].GetComponent<OrbItem>();
            //Perk Calculations
            perkSpread = 0;
            perkCooldown = 0;
            for (int i = 0; i < orbItem.perk.Count; i++)
            {
                perkSpread += orbItem.perk[i].spread;
                perkCooldown += orbItem.perk[i].cooldown;
            }

            meter.cdMax = TotalCooldown(currentOrb) + perkCooldown;
            meter.cd = meter.cdMax;
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            coroutine = StartCoroutine(meter.CooldownCounter());
            for (int i = 0; i < currentOrb.spell.Count; i++)
            {
                SpellItem spell = currentOrb.spell[i];
                var newSpell = Instantiate(spell.projectile, spellCastLoc.position, cam.rotation, projectiles);
                newSpell.transform.LookAt(dot.position);
                UpdateSpellInfo(newSpell, spell);
                newSpell.transform.Rotate(SpellSpread(spell) + NumSpread(perkSpread));
                if (newSpell.GetComponent<SpellMovement>())
                {
                    newSpell.GetComponent<SpellMovement>().currentOrb = orbInv.orb[selectedOrb];
                }
                if (newSpell.GetComponent<Bolt>())
                {
                    newSpell.GetComponent<Bolt>().currentBolt.GetComponent<BoltHolder>().currentOrb = orbInv.orb[selectedOrb];
                }
            }
        }
    }

    float perkSpread;
    float perkCooldown;

    public void UpdateSpellInfo (GameObject newSpell, SpellItem spell)
    {
        if (newSpell.GetComponent<Bolt>())
        {
            var bolt = newSpell.GetComponent<Bolt>();
            bolt.spell = spell;
            var boltHolder = bolt.boltHolder;
            var newBoltHolder = Instantiate(boltHolder, projectiles);
            newBoltHolder.GetComponent<BoltHolder>().spell = spell;
            bolt.currentBolt = newBoltHolder;

            var player = this.gameObject;
            bolt.player = player;
            Transform spellCastLoc = player.GetComponent<SpellCast>().spellCastLoc;
            var rate = spell.rate;
            StartCoroutine(newSpell.GetComponent<Bolt>().fireSegment(rate, spellCastLoc, cam));
        }
        if (newSpell.GetComponent<SpellMovement>())
        {
            newSpell.GetComponent<SpellMovement>().spell = spell;
        }
        if (newSpell.GetComponent<Teleport>())
        {
            newSpell.GetComponent<Teleport>().player = this.gameObject;
        }
    }
    Vector3 SpellSpread (SpellItem spell)
    {
        var spread = new Vector3(Random.Range(-spell.spread, spell.spread),Random.Range(-spell.spread, spell.spread),Random.Range(-spell.spread, spell.spread));
        return spread;
    }

    Vector3 NumSpread (float s)
    {
        var spread = new Vector3(Random.Range(-s, s),Random.Range(-s, s),Random.Range(-s, s));
        return spread;
    }
    

    void UpdateCurrentOrb()
    {
        selectedSlot = GetComponent<OrbSelect>().selectedSlot;
        currentOrb = orbInv.orb[selectedSlot].GetComponent<OrbItem>();
    }
}





