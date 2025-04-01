using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterMinigame : MonoBehaviour
{
    public bool great;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        great = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        great = false;
    }
}
