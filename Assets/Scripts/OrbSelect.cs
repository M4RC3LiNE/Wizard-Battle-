using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OrbSelect : MonoBehaviour
{
    [SerializeField] private Transform selected;

    [SerializeField] private List<Transform> slot;
    public int selectedSlot;
    void Update()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            if (selectedSlot < slot.Count - 1)
            {
                selectedSlot += 1;
            }
            else
            {
                selectedSlot = 0;
            }
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedSlot > 0)
            {
                selectedSlot -= 1;
            }
            else
            {
                selectedSlot = slot.Count - 1;
            }
        }
        selected.position = slot[selectedSlot].position;
    }

    
}
