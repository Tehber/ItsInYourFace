using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BobIA : MonoBehaviour
{
    public Transform target;
    public CircleCollider2D recruiterTrgg;
    public Camera cam;
    public GameObject attackTrgg;
    public GameObject attackP;
    public bool accompanying;
    public int nPal;
    public float distance;
    public bool walking;
    public Bobz bobInfo;
    public bool hungry;
    private void Awake()
    {
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                this.GetComponent<Animator>().SetInteger("Skin", 1);
            }
            else
            {
                this.GetComponent<Animator>().SetInteger("Skin", 0);
            }
        GameObject.Find("Jugador").transform.GetComponent<BaseManager>().bobs.Add(this.gameObject);
    }
    void FixedUpdate()
    {
        if (bobInfo == null)
        {
            Bobz newBobz = ScriptableObject.CreateInstance<Bobz>();
            newBobz.type = UnityEngine.Random.Range(0, 6);
            newBobz.baseForce = UnityEngine.Random.Range(0, 11);
            newBobz.baseCience = UnityEngine.Random.Range(0, 11);
            newBobz.baseSurvival = UnityEngine.Random.Range(0, 11);
            newBobz.baseCooking = UnityEngine.Random.Range(0, 11);
            newBobz.baseBuilding = UnityEngine.Random.Range(0, 11);
            newBobz.lives = UnityEngine.Random.Range(4, 8);
            if (newBobz.type == 0)
            {
                newBobz.baseForce += 1;
                newBobz.baseCience += 1;
                newBobz.baseSurvival += 1;
                newBobz.baseCooking += 1;
                newBobz.baseBuilding += 1;
            }
            if (newBobz.type == 1)
            {
                newBobz.baseForce += 3;
            }
            if (newBobz.type == 2)
            {
                newBobz.baseCience += 3;
            }
            if (newBobz.type == 3)
            {
                newBobz.baseSurvival += 3;
            }
            if (newBobz.type == 4)
            {
                newBobz.baseCooking += 3;
            }
            if (newBobz.type == 5)
            {
                newBobz.baseBuilding += 3;
            }
            newBobz.isBob = true;
            bobInfo = newBobz;
            this.GetComponentInChildren<BobDamage>().bobInfo = newBobz;
        }
        if (BaseManager.hungerState == 3)
        {
            bobInfo.force = bobInfo.baseForce * 2;
            bobInfo.cience = bobInfo.baseCience * 2;
            bobInfo.survival = bobInfo.baseSurvival * 2;
            bobInfo.cooking = bobInfo.baseCooking * 2;
            bobInfo.Building = bobInfo.baseBuilding * 2;
            hungry = false;
        }
        else if (BaseManager.hungerState == 2)
        {
            bobInfo.force = bobInfo.baseForce;
            bobInfo.cience = bobInfo.baseCience;
            bobInfo.survival = bobInfo.baseSurvival;
            bobInfo.cooking = bobInfo.baseCooking;
            bobInfo.Building = bobInfo.baseBuilding;
            hungry = false;
        }
        else if (BaseManager.hungerState == 1)
        {
            bobInfo.force = bobInfo.baseForce / 2;
            bobInfo.cience = bobInfo.baseCience / 2;
            bobInfo.survival = bobInfo.baseSurvival / 2;
            bobInfo.Building = bobInfo.baseBuilding / 2;
            hungry = false;
        }
        else if (BaseManager.hungerState == 0)
        {
            hungry = true;
            this.GetComponentInChildren<BobAttack>().Enemy.Clear();
        }
        if (hungry == true)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (hungry == false)
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (this.GetComponentInChildren<BobAttack>().Enemy.Count == 0 && hungry == false)
        {
            if (accompanying == true)
            {
                Vector3 direcction = new Vector2((target.transform.position.x - this.transform.position.x )/nPal, (target.transform.position.y - this.transform.position.y)/nPal);
                if (Vector2.Distance(this.transform.position, target.transform.position) >= distance)
                {
                    this.GetComponent<Rigidbody2D>().MovePosition(this.transform.position + direcction.normalized * bobInfo.velocity * Time.fixedDeltaTime);
                    this.GetComponent<Animator>().SetBool("Caminando", true);
                }
                else
                {
                    this.GetComponent<Animator>().SetBool("Caminando", false);
                }
                recruiterTrgg.enabled = false;
                if (nPal == Recruiter.numPal)
                {
                    Recruiter.lstPal = this.gameObject;
                }
            }
            if (accompanying == false)
            {
                target = (GameObject.Find("Jugador").transform);
                //se activa el trigger
                recruiterTrgg.enabled = true;
                this.GetComponent<Animator>().SetBool("Caminando", false);
            }
            this.GetComponent<Animator>().SetBool("Atacando", false);
        }
        if (this.GetComponentInChildren<BobAttack>().Enemy.Count != 0 && hungry == false)
        {
            if (this.GetComponentInChildren<BobAttack>().Enemy.Peek() != null)
            {
                target = this.GetComponentInChildren<BobAttack>().Enemy.Peek();
                Vector3 lookAt = this.GetComponentInChildren<BobAttack>().Enemy.Peek().transform.position - attackP.transform.position;
                attackP.transform.up = lookAt;
                if (Vector2.Distance(this.transform.position, this.GetComponentInChildren<BobAttack>().Enemy.Peek().position) >= 1.5)
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, this.GetComponentInChildren<BobAttack>().Enemy.Peek().position, bobInfo.velocity * Time.fixedDeltaTime);
                    this.GetComponent<Animator>().SetBool("Atacando", false);
                    this.GetComponent<Animator>().SetBool("Caminando", true);
                }
                if (1.5 >= Vector2.Distance(this.transform.position, this.GetComponentInChildren<BobAttack>().Enemy.Peek().position))
                {
                    this.GetComponent<Animator>().SetBool("Atacando", true);
                    this.GetComponent<Animator>().SetBool("Caminando", false);
                }
                if (this.GetComponentInChildren<BobAttack>().Enemy.Peek().CompareTag("Enemigo") == false)
                {
                    this.GetComponentInChildren<BobAttack>().Enemy.Dequeue();
                }
            }
            else
            {
                this.GetComponentInChildren<BobAttack>().Enemy.Dequeue();
            }
        }
        if (hungry == false)
        {
            if (target.transform.position.x - this.transform.position.x <= 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (0 <= target.transform.position.x - this.transform.position.x)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (bobInfo.lives <= 0)
        {
            Destroy(this.gameObject, 0.1f);
        }
    }
    public void Recruit()
    {
        //si el target está lo suficientemente cerca del bob, presiona la E, no lo estaba acompañando y no hay tantos bobs
        if (accompanying == false && 3 >= Vector2.Distance(GameObject.Find("Jugador").transform.position, this.transform.position) && 3 >= Recruiter.numPal && hungry == false)
        {
            //se suma un bob a la fila
            Recruiter.numPal += 1;
            nPal = Recruiter.numPal;
            distance = nPal * 3;
            Recruiter.lstPal = this.gameObject;
            target = (GameObject.Find("Jugador").transform);
            //activa el estado de acompañar
            accompanying = true;
        }
    }
    public void Leave()
    {
        //si es el ultimo en la fila
        if (Recruiter.lstPal == this.gameObject)
        {
            //deja de acompañar
            accompanying = false;
            nPal = 0;
            Recruiter.numPal -= 1;
            target = (GameObject.Find("Jugador").transform);
            distance = 0;
        }
    }
    public void Attack()
    {
        attackTrgg.GetComponent<CircleCollider2D>().enabled = true;
        attackTrgg.transform.localPosition = new Vector3(0, 1, 0);
    }
    public void Back()
    {
        attackTrgg.transform.localPosition = new Vector3(0, 0, 0);
        attackTrgg.GetComponent<CircleCollider2D>().enabled = false;
    }
    public void GoToStructure(Transform structure)
    {
        target = structure;
        accompanying = true;
        nPal = 1;
    }
}
