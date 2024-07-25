using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkItemSlot : MonoBehaviour
{
    public Perk perk;
    void Update()
    {
        if (GetComponent<Image>())
        {
            if (perk != null)
            {
                GetComponent<Image>().sprite = perk.itemImage;
                var col = GetComponent<Image>().color;
                col.a = 1;
                GetComponent<Image>().color = col;
            }
            else{
                GetComponent<Image>().sprite = null;
                var col = GetComponent<Image>().color;
                col.a = 0;
                GetComponent<Image>().color = col;
            }
            
        }
        
    }
}
