using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public SpellItem spell;
    public Perk perk;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemAttack;
    public TextMeshProUGUI itemCooldown;
    public TextMeshProUGUI itemRange;
    public TextMeshProUGUI itemSpread;
    public TextMeshProUGUI itemCost;
    public TextMeshProUGUI itemDesc;
    public TextMeshProUGUI itemDrag;
    public TextMeshProUGUI itemSpeed;
    public GameObject orbView;


    void Update()
    {
        if (spell)
        {
            itemName.text = spell.itemName;
            itemName.color = new Color32(195, 55, 41, 255);
            itemAttack.text = spell.attack.ToString();
            itemDesc.text = spell.itemDesc;
            itemCooldown.text = spell.cooldown.ToString();
            itemRange.text = spell.range.ToString();
            itemSpread.text = spell.spread.ToString();
            itemCost.text = spell.manaCost.ToString();
            if (spell.bolt)
            {
                itemDrag.text = spell.boltDrag.ToString();
            }
            else{
                itemDrag.text = spell.drag.ToString();
            }
            itemSpeed.text = spell.speed.ToString();
        } else if (perk)
        {
            itemName.text = perk.itemName;
            itemName.color = new Color32(32, 119, 128, 255);
            itemAttack.text = perk.attack.ToString();
            itemDesc.text = perk.itemDesc;
            itemCooldown.text = perk.cooldown.ToString();
            itemRange.text = perk.range.ToString();
            itemSpread.text = perk.spread.ToString();
            itemCost.text = perk.manaCost.ToString();
            itemDrag.text = perk.drag.ToString();
            itemSpeed.text = perk.speed.ToString();
        }
        
        if (!orbView.activeInHierarchy && !GameObject.Find("Player").GetComponent<ItemPickup>().lookingAtItem)
        {
            gameObject.SetActive(false);
        }
    }

    public void SpellInfoPopup(SpellItem s, GameObject itemInfoObj)
    {
        itemInfoObj.SetActive(true);
        spell = s;
    }
    public void PerkInfoPopup(Perk s, GameObject itemInfoObj)
    {
        itemInfoObj.SetActive(true);
        perk = s;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }
}
