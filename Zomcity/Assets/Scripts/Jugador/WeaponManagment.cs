using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManagment : MonoBehaviour
{
    public GameObject player;
    public GameObject timerObj;
    public GameObject weaponSprite;
    public GameObject weaponTrigger;
    public GameObject bullet;
    public GameObject pivot;
    public static float timer;
    public static bool impulse = false;
    public Weapons weapon;
    public PlayerInput controls;
    void FixedUpdate()
    {
        if (weapon != null)
        {
            //crea un timer con el cual hace mas grande el parent de la barrita de recarga usando la regla de 3
            timer = timer + Time.fixedDeltaTime;
            timerObj.transform.localScale = new Vector2((timer / weapon.reload), timerObj.transform.localScale.y);
            weaponSprite.GetComponent<SpriteRenderer>().enabled = true;
            //si el timer es mayor o igual al tiempo de la recarga del arma entonces desactiva el sprite del objeto y mantiene el timer en un punto fijo
            if (timer >= weapon.reload)
            {
                timer = weapon.reload;
                timerObj.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
            //si no, activa la barrita para que se muestre la recarga y se vea bonito
            else
            {
                timerObj.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            timerObj.GetComponentInChildren<SpriteRenderer>().enabled = false;
            weaponSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void OnDisparar()
    {
        if (weapon != null)
        {
            if (timer == weapon.reload && weapon.melee == true && Builder.isBuilding == false && impulse == false)
            {
                //se desactivan los controles del personaje, se le a�ade una fuerza en la direccion del golpe, se reinicia el timer y activa las animaciones del arma y su trigger
                impulse = true;
                player.GetComponent<Rigidbody2D>().AddForce(CameraSight.direction2 * 20, ForceMode2D.Impulse);
                Invoke("Detenerse", 0.1f);
                timer = 0;
                weaponTrigger.SetActive(false);
                weaponTrigger.GetComponent<Animator>().SetBool("Ataque", true);
                weaponSprite.GetComponent<Animator>().SetBool("Atacando", true);
            }
            if (timer == weapon.reload && weapon.melee == false && Builder.isBuilding == false && impulse == false)
            {
                impulse = true;
                player.GetComponent<Rigidbody2D>().AddForce(CameraSight.direction2 * -5, ForceMode2D.Impulse);
                Invoke("Detenerse", 0.1f);
                timer = 0;
                weaponSprite.GetComponent<Animator>().SetBool("Atacando", true);
                GameObject bulletPrefab = Instantiate(bullet,player.transform.position,pivot.transform.rotation);
                bulletPrefab.GetComponent<Attack>().managment = this.gameObject.GetComponent<WeaponManagment>();
                bulletPrefab.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.up * 1000 * Time.deltaTime;
                bulletPrefab = null;
            }
        }
    }
    public void Detenerse()
    {
        //se vuelven a activar los controles y se desctivan las animaciones del trigger y su arma 
       impulse = false;
        weaponTrigger.SetActive(true);
        weaponTrigger.GetComponent<Animator>().SetBool("Ataque", false);
        weaponSprite.GetComponent<Animator>().SetBool("Atacando", false);
    }
}
