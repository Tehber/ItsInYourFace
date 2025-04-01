using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectDrop : MonoBehaviour
{
    public Objects objectinfo;
    public Inventory inventory;
    public bool goTo;
    private void Awake()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        if (objectinfo == null )
        {
            objectinfo = inventory.allObjects[Random.Range(0,inventory.allObjects.Count())];
        }
    }
    void Update()
    {
        if (goTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Jugador").transform.position, 30 * Time.deltaTime);
        }
        if (transform.position == GameObject.Find("Jugador").transform.position && inventory.full == false)
        {
            inventory.AddItem(this.gameObject);
            Destroy(gameObject);
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = objectinfo.Sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador" && inventory.full == false)
        {
            goTo = true;
        }
    }
}
