using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSight : MonoBehaviour
{
    public Camera cam;
    public Transform Player;
    public float threshhold;
    public static Vector2 direction2;
    void Update()
    {
        //aumenta el limite de la camara
        if (Builder.isBuilding == true)
        {
            threshhold = 10;
        }
        else
        {
            threshhold = 4;
        }
        //no tengo idea como funciona este codigo pero funciona xD
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - Player.position);
        if (direction.magnitude > threshhold)
        {
            direction = direction.normalized * threshhold;
        }
        transform.position = (Player.position + direction);
        direction2 = new Vector2(direction.x, direction.y);
    }
}
