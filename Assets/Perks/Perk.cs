using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "New Perk", menuName = "Item/Perk")]

[System.Serializable]
public class Perk : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    [TextArea(10, 5)]
    public string itemDesc;
    public Sprite itemImage;

    [Header("Stat Changes")]
    public int manaCost;
    public float cooldown;
    public float range;
    public float spread;
    public float attack;
    public float speed;
    public float drag;
    public enum perk {None, Homing, Whole, Explosive};
    [Header("Custom Perk")]
    public perk ability;
    public GameObject explosion;








}
