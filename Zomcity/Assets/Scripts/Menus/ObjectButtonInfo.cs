using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ObjectButtonInfo : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public GameObject child;
    public WeaponManagment managment;
    public TextMeshProUGUI text;
    public int amount;

    public void OnDrop(PointerEventData eventData)
    {
        if (child == null)
        {
            GameObject droppped = eventData.pointerDrag;
            if (child == null && name != "Arma" && name != "Armadura")
            {
                ItemInInventory itemInInventory = droppped.GetComponent<ItemInInventory>();
                itemInInventory.parent = transform;
            }
            if (name == "Arma" && droppped.GetComponent<ItemInInventory>().objectInfo.weapon != null)
            {
                ItemInInventory itemInInventory = droppped.GetComponent<ItemInInventory>();
                itemInInventory.parent = transform;
            }
            if (name == "Armadura" && droppped.GetComponent<ItemInInventory>().objectInfo.armor != null)
            {
                ItemInInventory itemInInventory = droppped.GetComponent<ItemInInventory>();
                itemInInventory.parent = transform;
            }
        }
    }

    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
    }
    void Update()
    {
        if (name != "Arma" && name != "Armadura")
        {
            if (child != null)
            {
                if (child.GetComponent<ItemInInventory>().parent != gameObject)
                {
                    child = null;
                    amount = 0;
                }
                else
                {
                    child = transform.GetChild(0).gameObject;
                    text = child.GetComponentInChildren<TextMeshProUGUI>();
                }
            }
            if (amount == 1 && text != null)
            {
                text.enabled = false;
            }
            else if (text != null)
            {
                text.enabled = true;
                text.text = amount.ToString();
            }
        }
        if (name == "Arma" || name == "Armadura")
        {
            if (transform.childCount == 0)
            {
                child = null;
            }
            else
            {
                child = transform.GetChild(0).gameObject;
            }
        }
        if (name == "Arma" && child != null)
        {
            managment.weapon = child.GetComponent<ItemInInventory>().objectInfo.weapon;
        }
        if (name == "Arma" && child == null)
        {
            managment.weapon = null;
        }
        if (name == "Armadura" && child != null)
        {
            
        }
    }
}
