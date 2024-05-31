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
    }

    IEnumerator CastSpell(int n)
    {
        var inv = this.GetComponent<PlayerSpellPickup>().playerInventory;
        SpellItem spell = inv[n].item;
        Instantiate(spell.projectile, spellCastLoc.position, cam.rotation);
        yield return new WaitForSeconds(spell.fireRate);
    }
}
