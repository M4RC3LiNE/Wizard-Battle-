using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject itemInfoObj;
    public void OnPointerEnter(PointerEventData eventData)
    {
        var itemInfo = itemInfoObj.GetComponent<ItemInfo>();
        if (transform.GetChild(0).GetComponent<SpellItemSlot>() && transform.GetChild(0).GetComponent<SpellItemSlot>().spell != null)
        {
            itemInfo.SpellInfoPopup(this.transform.GetChild(0).GetComponent<SpellItemSlot>().spell, itemInfoObj);
        } else if (transform.GetChild(0).GetComponent<PerkItemSlot>() && transform.GetChild(0).GetComponent<PerkItemSlot>().perk != null)
        {
            itemInfo.PerkInfoPopup(this.transform.GetChild(0).GetComponent<PerkItemSlot>().perk, itemInfoObj);
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        itemInfoObj.SetActive(false);
        itemInfoObj.GetComponent<ItemInfo>().spell = null;
        itemInfoObj.GetComponent<ItemInfo>().perk = null;
    }
}
