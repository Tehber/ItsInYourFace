using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BobDamage : MonoBehaviour
{
    public GameObject blood;
    public Weapons weapons;
    public Bobz bobInfo;
    public GameObject vision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemigo"))
        {
            Vector2 direction = collision.transform.position - transform.position;
            vision.gameObject.GetComponent<BobAttack>().Enemy.Peek().gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            blood.SetActive(true);
            Invoke("sangreStop", 0.1f);
            collision.gameObject.GetComponent<EnemyIA>().enemyInfo.life -= weapons.damage + (bobInfo.force/2);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * weapons.knockback);
        }
    }
    public void sangreStop()
    {
        blood.SetActive(false);
        if (vision.gameObject.GetComponent<BobAttack>().Enemy.Count != 0 && vision.gameObject.GetComponent<BobAttack>().Enemy.Peek() != null)
        {
            vision.gameObject.GetComponent<BobAttack>().Enemy.Peek().gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
