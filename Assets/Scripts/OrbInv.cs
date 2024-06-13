using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbInv : MonoBehaviour
{


    [System.Serializable]
    public class OrbInventory
    {
        public Orb item;
        public GameObject slot;
        public OrbInventory(GameObject _slot, Orb _item)
        {
            slot = _slot;
            item = _item;
        }
    }
    [SerializeField] public List<OrbInventory> orbInv = new List<OrbInventory>();
}
