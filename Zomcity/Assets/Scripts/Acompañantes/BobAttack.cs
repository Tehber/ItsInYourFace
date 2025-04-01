using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAttack : MonoBehaviour
{
    public Queue<Transform> Enemy = new Queue<Transform>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Enemy.Enqueue(collision.gameObject.transform);
        }
    }
    private void Update()
    {
        if (Enemy.Count != 0)
        {
            if (Vector2.Distance(Enemy.Peek().transform.position, this.transform.position) >= 20)
            {
                Enemy.Dequeue();
            }
        }
    }
}
