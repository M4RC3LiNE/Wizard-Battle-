using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Item/Spell")]

[System.Serializable]
public class SpellItem : ScriptableObject
{
    [Header("Projectile")]
    [SerializeField] public GameObject projectile;
    


    [Header("Item Info")]
    [TextArea(10, 5)]
    [SerializeField] public string itemDesc;
    [SerializeField] public string itemName;
    [Header("Stats")]
    [SerializeField] public int manaCost;
    [SerializeField] public float cooldown;
    [SerializeField] public float range;
    [SerializeField] public float spread;
    [SerializeField] public float attack;
    [SerializeField] public float speed;
    [SerializeField] public float drag;
    
    [Header("Inventory Item")]
    [SerializeField] public Sprite image;

    [Header("Bolts")] 

    
    public bool bolt = false;
    [HideInInspector]public float rate;
    [HideInInspector]public int segments;
    [HideInInspector]public GameObject boltProjectile;
    [HideInInspector]public bool destroyOnTrigger;
    [HideInInspector]public float boltSpread;
    [HideInInspector]public float boltDrag;


        #region Editor
    #if UNITY_EDITOR
    [CustomEditor(typeof(SpellItem))]
    public class SpellItem_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var script = (SpellItem)target;
            //script.bolt = EditorGUILayout.Toggle("Bolt",script.bolt);
            if(!script.bolt)
                return;
            script.rate = EditorGUILayout.FloatField("Rate", script.rate);
            script.segments = EditorGUILayout.IntField("Segments", script.segments);
            script.boltProjectile = EditorGUILayout.ObjectField("Bolt Projectile", script.boltProjectile, typeof(GameObject),true) as GameObject;
            script.destroyOnTrigger = EditorGUILayout.Toggle("Destroy On Trigger",script.destroyOnTrigger);
            script.boltSpread = EditorGUILayout.FloatField("Spread", script.boltSpread);
            script.boltDrag = EditorGUILayout.FloatField("Bolt Drag", script.boltDrag);
        }
    }
    #endif
        #endregion






}

