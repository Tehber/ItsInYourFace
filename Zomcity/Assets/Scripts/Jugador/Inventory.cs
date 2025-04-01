using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public Objects[] allObjects = new Objects[29];
    public GameObject[] allObjectButtons = new GameObject[29];
    public List<Objects> inventory;
    public bool full;
    public GameObject inventoryUi;
    public GameObject inventoryUiChild;
    public GameObject equipmentUI;
    public GameObject chestUI;
    public PlayerInput controls;
    public InteractiveSight InteractiveSight;
    public GameObject itemInInventory;
    void Update()
    {
        if (inventory.Count() >= 16)
        {
            full = true;
        }
        else
        {
            full = false;
        }
    }
    public void AddItem(GameObject item)
    {
        if (full == false)
        {
            foreach (GameObject button in allObjectButtons)
            {
                if (button.GetComponent<ObjectButtonInfo>().child == null)
                {
                    button.GetComponent<ObjectButtonInfo>().child = Instantiate(itemInInventory,button.transform);
                    button.GetComponent<ObjectButtonInfo>().child.GetComponent<ItemInInventory>().objectInfo = item.GetComponent<ObjectDrop>().objectinfo;
                    inventory.Add(item.GetComponent<ObjectDrop>().objectinfo);
                    button.GetComponent<ObjectButtonInfo>().amount++;
                    return;
                }
                if (button.GetComponent<ObjectButtonInfo>().child.GetComponent<ItemInInventory>().objectInfo.id == item.GetComponent<ObjectDrop>().objectinfo.id)
                {
                    button.GetComponent<ObjectButtonInfo>().amount++;
                    return;
                }
            }
        }
    }
    public void OnAbrirMenu ()
    {
        if (InteractiveSight.bob == null && InteractiveSight.structure == null)
        {
            WeaponManagment.impulse = true;
            inventoryUi.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        WeaponManagment.impulse = false;
        inventoryUi.SetActive(false);
        inventoryUiChild.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        equipmentUI.SetActive(true);
    }
}
