using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour
{
    public Camera cam;
    public Transform sight;
    public GameObject Player;
    public GameObject weaponSprite;
    void Update()
    {
        //hace que la mira est� donde est� el cursor
        Vector2 mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        sight.position = mousepos;
        //verifica donde est� la mira localmente y flipea tanto el arma como al jugador
        if (sight.localPosition.x <= 0)
        {
            Player.GetComponent<SpriteRenderer>().flipX = true;
            weaponSprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            Player.GetComponent<SpriteRenderer>().flipX = false;
            weaponSprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        //desactiva el collider si se est� construyendo (creo que es innecesario)
        if (Builder.isBuilding == true)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
