using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch object");
        if (other.GetComponent<SpellItemObject>())
        {
            Debug.Log("Touched Spell");
            if (playerInventory.Count <= 4)
            {
                Debug.Log("Added Spell to inv");
                playerInventory.Add(new Inventory(1, other.GetComponent<SpellItemObject>().spell));
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

    [SerializeField] public List<Inventory> playerInventory = new List<Inventory>();
}
