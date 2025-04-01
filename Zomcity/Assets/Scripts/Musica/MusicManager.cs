using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource soundtrack1;
    public AudioSource soundtrack2; 
    void Start()
    {
        
    }
    void Update()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerMovement>().enemies.Count == 0)
            {
                soundtrack1.mute = false;
                soundtrack2.mute = true;
            }
            if (player.GetComponent<PlayerMovement>().enemies.Count != 0)
            {
                soundtrack1.mute = true;
                soundtrack2.mute = false;
            }
        }
    }
}
