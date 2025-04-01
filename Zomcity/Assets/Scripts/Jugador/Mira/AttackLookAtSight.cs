using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLookAtSight : MonoBehaviour
{
    public GameObject mira;
    void Update()
    {
        //hace que el parent del ataque mire hacia la mira
        Vector2 dir = mira.transform.localPosition;
        float ang = Vector2.SignedAngle(Vector2.up, dir);
        transform.localRotation = (Quaternion.AngleAxis(ang, Vector3.forward));
    }
}
