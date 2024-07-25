using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpellPopup : MonoBehaviour
{
    public bool newSpellOpen = false;
    public GameObject slot;
    public GameObject orbView;
    public GameObject player;
    public SpellItem spell;

    public void OpenNewSpell(SpellItem s)
    {
        if (!newSpellOpen)
        {
            spell = s;
            slot.GetComponent<SpellItemSlot>().spell = s;
            gameObject.SetActive(true);
            newSpellOpen = true;
            player.GetComponent<OrbInv>().OpenInv();

        }
    }

    void Update()
    {
        if (newSpellOpen)
        {
            gameObject.SetActive(true);
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
