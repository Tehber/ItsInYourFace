using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    public Transform structure;
    public GameObject bob;
    public InteractiveSight interactiveSight;
    public BobBuildings menuBobs;
    void Start()
    {
        interactiveSight = GameObject.Find("Mira").GetComponent<InteractiveSight>();
    }
    public void TakeOutBob()
    {
        menuBobs.bobs.Remove(bob);
        bob.transform.position = structure.position + new Vector3(0, -2.5f, 0);
    }
    public void PrepareBob()
    {
        interactiveSight.bob.GetComponent<BobIA>().GoToStructure(structure);
    }
    public void CloseMenu()
    {
        interactiveSight.bob = null;
        interactiveSight.structure = null;
        GameObject.Find("Mira").GetComponent<InteractiveSight>().CloseMenu();
    }
}
