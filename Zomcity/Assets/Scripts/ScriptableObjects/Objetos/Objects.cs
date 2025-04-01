using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "NewObject")]
public class Objects : ScriptableObject
{
    public int type; //1 objeto, 2 arma (melee), 3 arma (distancia), 4 armadura, 5 consumibles
    public int id;
    public string objectName;
    public Sprite Sprite;
    public Weapons weapon;
    public armor armor;
    public bool equippable;
    public bool crafteable;
    public List<int> ingredients;
}
