using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemInInventory : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Inventory inventory;
    public Objects objectInfo;
    public Transform parent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        gameObject.GetComponent<Image>().raycastTarget = false;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent);
        gameObject.GetComponent<Image>().raycastTarget = true;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().raycastTarget = true;
    }

    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
    }
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = inventory.allObjects[objectInfo.id].Sprite;
        gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
    }
}
