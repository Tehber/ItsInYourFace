using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuBobs : MonoBehaviour
{
    public GameObject structure;
    public GameObject menu;
    public InteractiveSight interactiveSight;
    public GameObject button;
    public List<GameObject> buttons;
    private void OnEnable()
    {
        structure = interactiveSight.structure;
        if (structure.GetComponent<BobBuildings>().bobs.Count != 0)
        {
            foreach (GameObject item in structure.GetComponent<BobBuildings>().bobs)
            {
                GameObject newButton = Instantiate(button, menu.transform);
                newButton.GetComponent<ButtonInfo>().bob = item;
                newButton.GetComponentInChildren<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                newButton.GetComponent<ButtonInfo>().structure = interactiveSight.structure.transform;
                newButton.GetComponent<ButtonInfo>().menuBobs = structure.GetComponent<BobBuildings>();
                if (item.GetComponent<BobIA>().bobInfo.type == 0)
                {
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Jeans";
                }
                else if (item.GetComponent<BobIA>().bobInfo.type == 1)
                {
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cientifico";
                }
                else if (item.GetComponent<BobIA>().bobInfo.type == 2)
                {
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Soldado";
                }
                else if (item.GetComponent<BobIA>().bobInfo.type == 3)
                {
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Chef";
                }
                else if (item.GetComponent<BobIA>().bobInfo.type == 4)
                {
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Explorador";
                }
                else
                {
                    newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Constructor";
                }               
                buttons.Add(newButton);
                newButton = null;
            }
        }
    }
    private void OnDisable()
    {
            foreach (GameObject item in buttons)
            {
                Destroy(item);
            }
    }
}
