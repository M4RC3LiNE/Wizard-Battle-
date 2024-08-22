using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewSpellOverride : MonoBehaviour ,IPointerClickHandler
{
    public GameObject newSpellPopup;
    private int clickedSlot;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        var spellPopup = newSpellPopup.GetComponent<NewSpellPopup>();
        if (spellPopup.newSpellOpen)
        {
            if (GetComponent<SpellItemSlot>())
            {
                var orbView = spellPopup.player.GetComponent<OrbInv>().orbView.GetComponent<OrbView>();
                for (int i = 0; i < orbView.spellSlot.Count; i++)
                {
                    if (this.gameObject == orbView.spellSlot[i].gameObject)
                    {
                        clickedSlot = i;
                    }
                }
                var selectedSlot = spellPopup.player.GetComponent<OrbSelect>().selectedSlot;
                Debug.Log(selectedSlot);
                var orbItem = spellPopup.player.GetComponent<OrbInv>().orb[selectedSlot].GetComponent<OrbItem>();
                if (orbItem.spell.Count >= clickedSlot + 1)
                {
                    orbItem.spell[clickedSlot] = spellPopup.spell;
                } else{
                    orbItem.spell.Add(spellPopup.spell);
                }
                
                Destroy(spellPopup.player.GetComponent<ItemPickup>().item);
                spellPopup.newSpellOpen = false;
                spellPopup.player.GetComponent<OrbInv>().CloseInv();
            }
        }
    }
}
