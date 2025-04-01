using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Converter : MonoBehaviour
{
    public Bobz bobInfo;
    public GameObject converterUI;
    public PlayerInput control;
    public GameObject Soldier;
    public bool helpeable;
    public bool playing;

    private void Update()
    {
        if (Vector2.Distance(GameObject.Find("Jugador").transform.position, this.gameObject.transform.position) <= 3)
        {
            helpeable = true;
        }
        else
        {
            helpeable = false;
        }
    }
    void OnInteractuar()
    {
        if (helpeable == true)
        {
            if (playing == false)
            {
                bobInfo = this.gameObject.GetComponent<EnemyIA>().bobInfo;
                converterUI.SetActive(true);
                WeaponManagment.impulse = true;
                converterUI.transform.position = GameObject.Find("Jugador").transform.position;
                playing = true;
            }
            else
            {
                if (converterUI.GetComponentInChildren<ConverterMinigame>().great == true)
                {
                    GameObject newBob = Instantiate(Soldier, transform.position, transform.rotation);
                    bobInfo.isBob = true;
                    newBob.GetComponent<BobIA>().bobInfo = bobInfo;
                    converterUI.SetActive(false);
                    newBob.GetComponentInChildren<BobDamage>().bobInfo = bobInfo;
                    playing = false;
                    Destroy(this.gameObject, 0f);
                    WeaponManagment.impulse = false;
                }
                else
                {
                    converterUI.SetActive(false);
                    playing = false;
                    Destroy(this.gameObject, 0f);
                    WeaponManagment.impulse = false;
                }
            }
        }
    }
}
