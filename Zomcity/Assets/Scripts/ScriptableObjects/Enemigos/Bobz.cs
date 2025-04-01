using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bob", menuName = "NewBob")]
public class Bobz : ScriptableObject
{
    //0 = jeans, 1 = cientifico, 2 = soldado, 3 = chef, 4 = explorador, 5 = construcctor
    public int type;
    public int baseForce;
    public int baseCience;
    public int baseSurvival;
    public int baseCooking;
    public int baseBuilding;
    public int force;
    public int cience;
    public int survival;
    public int cooking;
    public int Building;
    public int lives;
    public bool isBob = false;
    public float velocity = 15;
}
