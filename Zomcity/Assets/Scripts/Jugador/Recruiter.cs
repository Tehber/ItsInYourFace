using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class Recruiter : MonoBehaviour
{
    public BobIA pal;
    public PlayerInput controls;
    public static GameObject lstPal;
    public static int numPal = 0;
    public static bool recruitable = false;
    private void Awake()
    {
        pal = this.gameObject.GetComponentInParent<BobIA>();
    }
    //cuando se presiona la E se activa el metodo recruit en scrpit de BobIA
    void OnInteractuar()
    {
            pal.Recruit();
    }
    //al presionar la F se encuentra al ultimo bob y se activa el metodo leave de BobIA
    void OnCancelar()
    {
            pal.Leave();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Jugador")
        {
            recruitable = true;
        }       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Jugador")
        {
            recruitable = false;
        }        
    }
}
