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
            for (int i = 0; i < playerInventory.Count; i++)
            {
                if (playerInventory[i] == null)
                {
                    playerInventory.Remove(playerInventory[i]);
                }
            }
            if (playerInventory.Count < 4)
            {
                playerInventory.Add(new Inventory(1, other.GetComponent<SpellItemObject>().spell));
                UpdateInventory();
                
                Destroy(other.gameObject);
            }
        }
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < 3; i++)
        {

            for (int n = 0; n < slot[i].childCount; n++)
            {
                Destroy(slot[i].GetChild(n).gameObject);
            }

            if (playerInventory[i].item)
            {
                var newItem = Instantiate(spellItem, slot[i].position, Quaternion.identity, slot[i]);

                newItem.GetComponent<SpellItemSlot>().spell = playerInventory[i].item;
            }
            
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            UpdateInventory();
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
