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
        GetComponent<RawImage>().texture = spell.image;

    }
}
