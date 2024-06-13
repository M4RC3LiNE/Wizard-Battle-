using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCast : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(CastOrb(this.GetComponent<OrbSelect>().selectedSlot));
        }
    }


    IEnumerator CastOrb(int n)
    {
        var inv = this.GetComponent<OrbInv>().orbInv;
        Orb orb = inv[n].item;
        if (orb)
        {


            var newSpell = Instantiate(spell.projectile, spellCastLoc.position, cam.rotation);
            newSpell.GetComponent<SpellMovement>().range = spell.range;
            yield return new WaitForSeconds(spell.fireRate);
        }
    }

}
