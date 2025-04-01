using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float velocity;
    public GameObject attackTrgg;
    public GameObject attackP;
    public Bobz bobInfo;
    public Enemy enemyInfo;
    public bool isB = true;
    //recuerda cambiar el nombre de las animaciones
    private void Awake()
    {
        if (enemyInfo == null)
        {
            Enemy newEnemy = ScriptableObject.CreateInstance<Enemy>();
            newEnemy.EnemyName = "Bobz";
            newEnemy.damage = Random.Range(1, 3);
            newEnemy.velocity = Random.Range(4, 8);
            newEnemy.melee = true;
            newEnemy.life = Random.Range(5, 8);
            newEnemy.knockback = 7000;
            enemyInfo = newEnemy;
            GetComponentInChildren<EnemyAttack>().enemyInfo = newEnemy;
        }
        if (isB == true && bobInfo == null)
        {
            Bobz newBobz = ScriptableObject.CreateInstance<Bobz>();
            newBobz.type = Random.Range(0, 6);
            newBobz.baseForce = Random.Range(0, 11);
            newBobz.baseCience = Random.Range(0, 11);
            newBobz.baseSurvival = Random.Range(0, 11);
            newBobz.baseCooking = Random.Range(0, 11);
            newBobz.baseBuilding = Random.Range(0, 11);
            newBobz.lives = Random.Range(4, 8);
            newBobz.isBob = false;
            if (newBobz.type == 1)
            {
                newBobz.force += 3;
            }
            if (newBobz.type == 2)
            {
                newBobz.cience += 3;
            }
            if (newBobz.type == 3)
            {
                newBobz.survival += 3;
            }
            if (newBobz.type == 4)
            {
                newBobz.cooking += 3;
            }
            if (newBobz.type == 5)
            {
                newBobz.Building += 3;
            }
            bobInfo = newBobz;
            GetComponent<Animator>().SetInteger("Skin", newBobz.type);
        }
    }
    void FixedUpdate()
    {
        //todo este codigo se ejecuta solamente si se encuentra a algo en su vision (EnemyVision para mas info)
        if (this.GetComponentInChildren<EnemyVision>().victim != null)
        {   
            // flipea el sprite para que mire mejor a la victima
            if (this.transform.position.x- this.GetComponentInChildren<EnemyVision>().victim.position.x >= 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            //hace que el parent del trigger del ataque mire a la victima (así la animacion ataca a la victima independiente de donde está)
            Vector3 lookAt = this.GetComponentInChildren<EnemyVision>().victim.position - attackP.transform.position;
            attackP.transform.up = lookAt;
            //mide la distancia, si esta a menos de 1.5 unidades, reproduce tanto la animacion del trigger como del sprite
            if (Vector2.Distance(this.GetComponentInChildren<EnemyVision>().victim.position, this.transform.position) <= 1.5)
            {
                this.GetComponent<Animator>().SetBool("Atacando", true);
            }
            //si esta mas lejos de  1.5 unidades, desactiva las animaciones de ataque y mueve el enemigo hasta la victima
            else
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, this.GetComponentInChildren<EnemyVision>().victim.position, velocity * Time.fixedDeltaTime);
                this.GetComponent<Animator>().SetBool("Atacando", false);
            }
        } 
        else
        {
            this.GetComponent<Animator>().SetBool("Atacando", false);
        }
        //se destruye cuando las vidas llegan a 0 (debe modificarse para los bobz)
        if (enemyInfo.life <= 0)
        {
            if (isB == true)
            {
                this.gameObject.tag = "Untagged";
                this.GetComponent<Converter>().enabled = true;
                this.GetComponent<EnemyIA>().enabled = false;
            }
            else
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
    public void Attack()
    {
        attackTrgg.GetComponent<CircleCollider2D>().enabled = true;
        attackTrgg.transform.localPosition = new Vector3(0, 1, 0);
    }
    public void Back()
    {
        attackTrgg.GetComponent<CircleCollider2D>().enabled = false;
        attackTrgg.transform.localPosition = new Vector3(0, 0, 0);
    }
}
