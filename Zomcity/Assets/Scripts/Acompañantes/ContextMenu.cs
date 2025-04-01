using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    public List<GameObject> structures;
    public GameObject button;
    public GameObject menu;
    public GameObject statsMenu;
    public InteractiveSight interactiveSight;
    public static int number;
    public void AddStructure()
    {     
        GameObject newButton = Instantiate(button, menu.transform);
        newButton.GetComponentInChildren<Image>().sprite = structures[number].GetComponent<SpriteRenderer>().sprite;
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = structures[number].GetComponent<BobBuildings>().structureInfo.structureName;
        newButton.GetComponent<ButtonInfo>().structure = structures[number].transform;
        number ++;
    }
    private void OnEnable()
    {
        statsMenu.GetComponent<TextMeshProUGUI>().text = "Fuerza: " + interactiveSight.bob.GetComponent<BobIA>().bobInfo.force + Environment.NewLine +
            "Ciencia: " + interactiveSight.bob.GetComponent<BobIA>().bobInfo.cience + Environment.NewLine +
            "Supervivencia: " + interactiveSight.bob.GetComponent<BobIA>().bobInfo.survival + Environment.NewLine +
            "Cocina: " + interactiveSight.bob.GetComponent<BobIA>().bobInfo.cooking + Environment.NewLine +
            "Construccion: " + interactiveSight.bob.GetComponent<BobIA>().bobInfo.Building;
    }
}
