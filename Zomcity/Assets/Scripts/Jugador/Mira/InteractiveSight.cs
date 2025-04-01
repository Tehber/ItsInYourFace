using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractiveSight : MonoBehaviour
{
    public RectTransform contextMenu;
    public Camera cam;
    public Vector3 bobPosition;
    public bool showMenu;
    public PlayerInput playerInput;
    public GameObject UI;
    public GameObject structureUI;
    public GameObject bob;
    public GameObject structure;
    private void Update()
    {
        bobPosition = this.gameObject.transform.position + new Vector3(0, 0.5f, 0);
        Vector3 screenPosition = cam.WorldToScreenPoint(bobPosition);
        contextMenu.position = screenPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //comprueba si el cursor está en un bob y activa su minimenú contextual
        if (collision.CompareTag("Resistencia") && collision.name != "Jugador")
        {
            contextMenu.gameObject.SetActive(true);
            bob = collision.gameObject;
            if (Vector2.Distance(GameObject.Find("Jugador").transform.position, collision.transform.position) <= 3)
            {
                contextMenu.GetComponent<TextMeshProUGUI>().text = "Q / E";
            }
            else
            {
                contextMenu.GetComponent<TextMeshProUGUI>().text = "Q";
            }
            if (collision.GetComponent<BobIA>().accompanying == true)
            {
                contextMenu.GetComponent<TextMeshProUGUI>().text = "F";
            }
        }
        if (collision.CompareTag("Construccion") && collision.GetComponent<BobBuildings>())
        {
            structure = collision.gameObject;
            contextMenu.gameObject.SetActive(true);
            contextMenu.GetComponent<TextMeshProUGUI>().text = "Q";
        }
        if (collision.CompareTag("Construccion") && collision.GetComponent<Chests>())
        {
            structure = collision.gameObject;
            contextMenu.gameObject.SetActive(true);
            contextMenu.GetComponent<TextMeshProUGUI>().text = "Q";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Resistencia") && collision.name != "Jugador")
        {
            contextMenu.gameObject.SetActive(false);
        }
        if (UI.gameObject.activeSelf == false)
        {
            if (collision.CompareTag("Resistencia") && collision.name != "Jugador")
            {
                bob = null;
            }
        }
        if (collision.CompareTag("Construccion") && collision.GetComponent<BobBuildings>())
        {
            structure = null;
            contextMenu.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Construccion") && collision.GetComponent<Chests>())
        {
            structure = null;
            contextMenu.gameObject.SetActive(false);
        }
    }
    public void OnAbrirMenu()
    {
        if (bob != null && bob.GetComponent<BobIA>().accompanying == false)
        {
            UI.SetActive(true);
            WeaponManagment.impulse = true;
        }
        if (structure != null && structure.GetComponent<BobBuildings>() == true)
        {
            structureUI.SetActive(true);
            WeaponManagment.impulse = true;
        }
        if (structure != null && structure.GetComponent<Chests>() == true)
        {
            structure.GetComponent<Chests>().OpenMenu();
            WeaponManagment.impulse = true;
        }
    }
    public void CloseMenu()
    {
        UI.SetActive(false);
        structureUI.SetActive(false);
        bob = null;
        structure = null;
        WeaponManagment.impulse = false;
    }
}
