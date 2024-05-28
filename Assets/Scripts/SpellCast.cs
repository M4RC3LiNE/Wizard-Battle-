using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellCast : MonoBehaviour
{
    [SerializeField] private Transform spellCastLoc;
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            var inv = this.GetComponent<PlayerSpellPickup>().playerInventory;
            SpellItem spell = inv[0].item;

            Instantiate(spell.projectile);

        }
    }
}
