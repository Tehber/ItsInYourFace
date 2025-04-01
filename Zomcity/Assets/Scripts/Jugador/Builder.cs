using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Builder : MonoBehaviour
{
    public PlayerInput controls;
    public GameObject menu;
    public static bool isBuilding;
    public Constructions construction;
    public Constructions[] construcions = new Constructions[11];
    public int counter;
    public Transform sight;
    public GameObject setter;
    public Vector2 grid;
    public int selection;
    public RectTransform cnstrcctnName;
    public Camera cam;
    public GameObject contextMenu;
    public BaseManager manager;
    private void Awake()
    {
        construction = construcions[counter];
    }
    void Update()
    {
        //el setter es el fantasma de la construccion
        if (setter != null)
        {
            //redondea la posicion de la mira para que se haga una especie de grid
            grid = new Vector3(
                (float)System.Math.Round(sight.transform.position.x),
                (float)System.Math.Round(sight.transform.position.y)
            );
            //el setter se posiciona donde está la grid
            setter.transform.position = grid;
            //este codigo busca si el setter tiene algo encima (en PhantomBuilding hay mas info), si hay algo encima pinta el setter de rojo
            if (PhantomBuilding.used == true)
            {
                setter.GetComponent<SpriteRenderer>().color = new Vector4(1, 0, 0, 0.5f);
            }
            else
            {
                setter.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0.5f);
            }
            //en un vector3 llamado screenPosition, se guarda la transformacion de las coordenadas a lugar en pantalla de este objeto
            Vector3 screenPosition = cam.WorldToScreenPoint(setter.transform.position + new Vector3(5, -2.5f, 0));
            //el UI se mueve a screenposition
            cnstrcctnName.position = screenPosition;
            cnstrcctnName.GetComponent<TextMeshProUGUI>().text = construction.structureName;
        }
        if(isBuilding == true && counter <= 11 && counter >= 0)
        {
            if (controls.actions["Cambiar"].ReadValue<Vector2>().y < 0)
            {
                counter++;
                if (counter > 11)
                {
                    counter = 0;
                }
                ChageStructure();
            }
            if (controls.actions["Cambiar"].ReadValue<Vector2>().y > 0)
            {
                counter--;
                if (counter < 0)
                {
                    counter = 11;
                }
                ChageStructure();
            }
            
        }
    }
    void OnConstruir()
    {
        //al presionar la "i" se intercambia entre modo construccion y modo libre
        if (isBuilding == false)
        { 
            isBuilding = true;
            menu.SetActive(true);
            //aqui se crea el setter
            setter = Instantiate(construction.structure, sight.position, new quaternion(0, 0, 0, 0));
            setter.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        { 
            isBuilding = false;
            menu.SetActive(false);
            Destroy(setter);
        }
    }
    void OnDisparar()
    {
        //al dar click, si se esta construyendo, y no hay nada encima del setter se crea otro clon del edificio seleccionado
        if (isBuilding == true && PhantomBuilding.used == false)
        {
            GameObject seted = Instantiate(construction.structure,setter.transform.position, new quaternion(0,0,0,0));
            seted.GetComponent<PhantomBuilding>().enabled = false;
            if (construction.structureName != "Barricada" && construction.structureName != "Torreta" && construction.structureName != "Almacen")
            {
                contextMenu.GetComponent<ContextMenu>().structures.Add(seted);
                contextMenu.GetComponent<ContextMenu>().AddStructure();
            }
            if (construction.structureName == "Cocina")
            {
                manager.kitchens.Add(seted);
            }
            if (construction.structureName == "laboratorio")
            {
                manager.labs.Add(seted);
            }
            seted = null;        
        }
    }
    void ChageStructure()
    {
        Destroy(setter,0f);
        construction = construcions[counter];
        setter = Instantiate(construction.structure, sight.position, new quaternion(0, 0, 0, 0));
        setter.GetComponent<BoxCollider2D>().enabled = false;
    }
}
