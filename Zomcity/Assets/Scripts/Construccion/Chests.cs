using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject chestsUI;
    public GameObject allUI;
    public GameObject equipmentUI;
    public Inventory inventorymanager;
    private void Awake()
    {
        inventorymanager = GameObject.Find("InventoryManager").GetComponent<Inventory>();
    }
    void Update()
    {
        allUI = inventorymanager.inventoryUi;
        inventoryUI = inventorymanager.inventoryUiChild;
        chestsUI = inventorymanager.chestUI;
        equipmentUI = inventorymanager.equipmentUI;
    }
    public void OpenMenu()
    {
        allUI.SetActive(true);
        inventoryUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(-160,0);
        equipmentUI.SetActive(false);
    }
}
