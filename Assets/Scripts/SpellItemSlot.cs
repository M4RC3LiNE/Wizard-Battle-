using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellItemSlot : MonoBehaviour
{
    public SpellItem spell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>())
        {
            if (spell != null)
            {
                GetComponent<Image>().sprite = spell.image;
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
