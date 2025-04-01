using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector2 direction;
    public WeaponManagment managment;
    public GameObject blood;
    public GameObject coll;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemigo"))
        {
            //si detecta al enemigo, activa un sistema de particulas "blood", saca la direccion en la que deberia salir volando el enemigo y aplica esa fuerza
            blood.SetActive(true);
            if(coll == null)
            {
                coll = collision.gameObject;
            }
            coll.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("sangreStop", 0.1f);
            direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction*managment.weapon.knockback);
            collision.gameObject.GetComponent<EnemyIA>().enemyInfo.life = collision.gameObject.GetComponent<EnemyIA>().enemyInfo.life - managment.weapon.damage;
        }
    }
    public void sangreStop()
    {
        //desactiva y reinicia las particulas
        blood.SetActive(false);
        if(coll != null)
        {
            coll.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        coll = null;
    }
}
