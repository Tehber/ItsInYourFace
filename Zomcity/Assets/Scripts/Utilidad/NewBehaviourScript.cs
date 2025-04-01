using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NewBehaviourScript : MonoBehaviour
{
    public Inventory from;
    public Inventory to;
    private void Update()
    {
        foreach (Objects item in from.allObjects)
        {
            to.allObjects[item.id] = item;
        }
    }
}
