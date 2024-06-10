using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellCast : MonoBehaviour
{
    [SerializeField] private Transform spellCastLoc;
    [SerializeField] private Transform cam;
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            StartCoroutine(CastSpell(0));

        }

        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(CastSpell(1));

        }
        if (Input.GetKey(KeyCode.F))
        {
            StartCoroutine(CastSpell(2));

        }
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(CastSpell(3));

        }
    }

    IEnumerator CastSpell(int n)
    {
        var inv = this.GetComponent<PlayerSpellPickup>().playerInventory;
        SpellItem spell = inv[n].item;
        var newSpell = Instantiate(spell.projectile, spellCastLoc.position, cam.rotation);
        newSpell.GetComponent<SpellMovement>().range = spell.range;
        yield return new WaitForSeconds(spell.fireRate);
    }
}
