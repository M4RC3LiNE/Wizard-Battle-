using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellPickup : MonoBehaviour
{

    [Header("Inventory Items")]
    public GameObject spellItem;

    public List <Transform> slot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SpellItemObject>())
        {
            if (playerInventory.Count <= 4)
            {
                playerInventory.Add(new Inventory(1, other.GetComponent<SpellItemObject>().spell));
                

                

                var newItem = Instantiate(spellItem, slot[playerInventory.Count - 1].position, Quaternion.identity, slot[playerInventory.Count - 1]);
                newItem.GetComponent<SpellItemSlot>().spell = other.GetComponent<SpellItemObject>().spell;


                Destroy(other.gameObject);

            }
            
            
        }
    }

    [System.Serializable]
    public class Inventory
    {
        public int amount;
        public SpellItem item;
        public Inventory(int _amount, SpellItem _item)
        {
            amount = _amount;
            item = _item;
        }
    }
    [Header("Inventory Data")]
    [SerializeField] public List<Inventory> playerInventory = new List<Inventory>();
}
