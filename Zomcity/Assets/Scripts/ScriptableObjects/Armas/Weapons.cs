using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arma", menuName = "Arma nueva")]
public class Weapons : ScriptableObject
{
    public string objName;
    public int damage;
    public float reload;
    public float knockback;
    public bool melee;
    public bool auto;
}
