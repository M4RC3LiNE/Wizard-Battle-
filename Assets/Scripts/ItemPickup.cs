using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    Ray ray;
	RaycastHit hit;
    public Camera cam;
    public bool lookingAtItem;
    public GameObject toolTip;
    public GameObject newSpellPopup;
	void Update()
	{
		ray = cam.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
            GameObject item = hit.transform.gameObject;
            if (Vector3.Distance(this.transform.position, hit.transform.position) < 20)
            {
                if (item.GetComponent<SpellItemObject>())
                {
                    lookingAtItem = true;
                    var spell = item.GetComponent<SpellItemObject>().spell;
                    toolTip.GetComponent<ItemInfo>().SpellInfoPopup(spell, toolTip);
                    if (Input.GetKey(KeyCode.E))
                    {
                        newSpellPopup.GetComponent<NewSpellPopup>().OpenNewSpell(spell);
                    }
                }
                else{
                    lookingAtItem = false;
                }
            }
            else{
                lookingAtItem = false;
            }
		}
        else{
            lookingAtItem = false;
        }
	}
}
