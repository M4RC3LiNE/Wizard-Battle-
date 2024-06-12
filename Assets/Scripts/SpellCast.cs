using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellCast : MonoBehaviour
{
    [SerializeField] private Transform spellCastLoc;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform selected;
    public int selectedSlot;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(CastSpell(selectedSlot));
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            if (selectedSlot < 3)
            {
                selectedSlot += 1;
            }
            else
            {
                selectedSlot = 0;
            }
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedSlot > 0)
            {
                selectedSlot -= 1;
            }
            else
            {
                selectedSlot = 3;
            }


            
        }

        selected.position = GetComponent<PlayerSpellPickup>().slot[selectedSlot].position;

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
