using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemigo", menuName = "Enemigo nuevo")]
public class Enemy : ScriptableObject
{
    public string EnemyName;
    public int damage;
    public float velocity;
    public bool melee;
    public float knockback;
    public int life;
}
