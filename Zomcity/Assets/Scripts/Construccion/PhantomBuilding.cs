using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomBuilding : MonoBehaviour
{
    public static bool used;
    public int counter;
    void Update()
    {
        //si no hay nada dentro del trigger de la construccion, esta libre
        if (counter == 0)
        { used = false; }
        else
        { used = true; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //impide construir cerca de otras construcciones o encima de bobs o el jugador
        if (collision.CompareTag("Construccion") || collision.CompareTag("Resistencia"))
        {
            counter++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Construccion") || collision.CompareTag("Resistencia"))
        {
            counter--;
        }
    }
}
