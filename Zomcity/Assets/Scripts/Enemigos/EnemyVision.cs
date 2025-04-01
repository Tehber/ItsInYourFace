using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    //recuerda cambiar el nombre de todas las tag
    public Transform victim;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cuando un objeto con el tag "Resistencia" entre al trigger va a asignar su transform a victim
        if (victim == null)
        {
            if (collision.CompareTag("Resistencia"))
            {
                victim = collision.transform;
            }
        }
        if (collision.name == "Jugador")
        {
            collision.GetComponent<PlayerMovement>().enemies.Add(this.gameObject);
        }
    }
    private void Update()
    {
        player = GameObject.Find("Jugador");
        if (victim != null)
        {
            if (Vector2.Distance(victim.position,this.transform.position) >= 20)
            {
                victim = null;      
            }
        }
        if (Vector2.Distance(player.transform.position, this.transform.position) >= 20)
        {
            player.GetComponent<PlayerMovement>().enemies.Remove(this.gameObject);
        }
    }
}
