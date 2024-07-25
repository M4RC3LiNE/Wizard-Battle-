using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbInv : MonoBehaviour
{
    public List<GameObject> orb;

    public GameObject orbView;
    public GameObject newSpellPopup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //open
            if (!orbView.activeInHierarchy)
            {
                OpenInv();
            }
            //close
            else if (!newSpellPopup.GetComponent<NewSpellPopup>().newSpellOpen)
            {
                CloseInv();
            }
        }
    }

    void Start()
    {
        orbView.SetActive(false);
    }

    public void OpenInv()
    {
        for (int i = 0; i < 3; i++)
        {
            orbView.GetComponent<OrbView>().spellSlot[i].GetComponent<SpellItemSlot>().spell = null;
            orbView.GetComponent<OrbView>().perkSlot[i].GetComponent<PerkItemSlot>().perk = null;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        orbView.SetActive(true);
        var orbViewScript = orbView.GetComponent<OrbView>();
        var slot = this.GetComponent<OrbSelect>().selectedSlot;
        for (int i = 0; i < orb[slot].GetComponent<OrbItem>().spell.Count; i++)
        {
            if (orb[slot].GetComponent<OrbItem>().spell[i])
            {
                orbViewScript.spellSlot[i].GetComponent<SpellItemSlot>().spell = orb[slot].GetComponent<OrbItem>().spell[i];
            }
        }

        for (int i = 0; i < orb[slot].GetComponent<OrbItem>().perk.Count; i++)
        {
            if (orb[slot].GetComponent<OrbItem>().perk[i]) 
            {
                orbViewScript.perkSlot[i].GetComponent<PerkItemSlot>().perk = orb[slot].GetComponent<OrbItem>().perk[i];
            }
        }
    }

    public void CloseInv()
    {
        newSpellPopup.GetComponent<NewSpellPopup>().newSpellOpen = false;
        orbView.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            orbView.GetComponent<OrbView>().spellSlot[i].GetComponent<SpellItemSlot>().spell = null;
            orbView.GetComponent<OrbView>().perkSlot[i].GetComponent<PerkItemSlot>().perk = null;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
