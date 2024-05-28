using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Item/Spell")]

[System.Serializable]
public class SpellItem : ScriptableObject
{
    [Header("Projectile")]
    [SerializeField] public GameObject projectile;
    [SerializeField] public float fireRate;


    [Header("Item Info")]
    [TextArea(10, 5)]
    [SerializeField] public string itemDesc;
    [SerializeField] public string itemName;
    [SerializeField] public int manaCost;



}