using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BobBuildings : MonoBehaviour
{
    public List<GameObject> bobs;
    public Constructions structureInfo;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BobIA>())
        {
            if (collision.GetComponent<BobIA>().target == this.transform)
            {
                bobs.Add(collision.gameObject);
                collision.transform.position = new Vector3(1000, 1000, 0);
                collision.GetComponent<BobIA>().accompanying = false;
                collision.GetComponent<BobIA>().target = null;
                collision.GetComponent<BobIA>().nPal = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<BobIA>())
        {
            if (collision.GetComponent<BobIA>().target == this.transform)
            {
                bobs.Add(collision.gameObject);
                collision.transform.position = new Vector3(1000, 1000, 0);
                collision.GetComponent<BobIA>().accompanying = false;
                collision.GetComponent<BobIA>().target = null;
                collision.GetComponent<BobIA>().nPal = 0;
            }
        }
    }
}
