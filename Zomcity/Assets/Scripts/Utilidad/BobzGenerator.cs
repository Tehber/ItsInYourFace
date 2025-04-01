using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BobzGenerator : MonoBehaviour
{
    public GameObject player;
    public PlayerInput controls;
    public GameObject Bobz;
    void Start()
    {
        player = GameObject.Find("Jugador");
    }
    void Update()
    {

    }
    public void OnInteractuar()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= 3)
        {
            GameObject bobz = Instantiate(Bobz, transform.position + new Vector3(3, 0, 0), transform.rotation);
        }
    }
}
