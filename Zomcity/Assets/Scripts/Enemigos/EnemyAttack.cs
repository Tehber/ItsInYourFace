using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Enemy enemyInfo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cuando el trigger del ataque impacte con un objeto con el tag resistencia, se saca la direccion del golpe, y con esa direccion se aplica el knockback
        //ademas, se le resta el daño
        if (collision.gameObject.CompareTag("Resistencia"))
        {
            /*Vector2 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * enemyInfo.knockback);*/
            if (collision.gameObject.name == "Jugador")
            {
                WeaponManagment.impulse = true;
                Invoke("Stop", 0.1f);
                PlayerMovement.lives -= enemyInfo.damage;
            }
            if (collision.gameObject.GetComponent<BobIA>())
            {
                    collision.gameObject.GetComponent<BobIA>().bobInfo.lives -= enemyInfo.damage;
            }
        }
    }
    public void Stop()
    {
        //para que el input del jugador no afecte mientras se recibe el knockback, se desactiva momentaneamente, (ver PlayerAttack para mas info)
        WeaponManagment.impulse = false;
    }
}
