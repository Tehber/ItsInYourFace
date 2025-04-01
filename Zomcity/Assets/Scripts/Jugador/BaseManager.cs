using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public List<GameObject> kitchens;
    public List<GameObject> labs;
    public List<GameObject> bobs;
    public List<int> foodPerBob;
    public float food = 3;
    public TextMeshProUGUI foodText;
    public float hunger;
    public static int hungerState; //0: desmayados, 1: debiles, 2: normales, 3: bien alimentados
    public float cience;
    void Update()
    {
        bobs.RemoveAll(bob => bob == null);
        hunger = bobs.Count/2f;
        if (food >= hunger *2)
        {
            hungerState = 3;
        }
        else if (food >= hunger && food < hunger*2)
        {
            hungerState = 2;
        }
        else if (food < hunger && food >= hunger/2)
        {
            hungerState = 1;
        }
        else if (food < hunger / 2)
        {
            hungerState = 0;
        }
        foreach (GameObject kitchen in kitchens)
        {
            foreach (GameObject bob in kitchen.GetComponent<BobBuildings>().bobs)
            {
                foodPerBob.Add(bob.GetComponent<BobIA>().bobInfo.cooking);
            }
        }
        food = foodPerBob.Sum() + 2;
        foodPerBob.Clear();
        foodText.text = "Comida: " + (food - hunger);
    }
}
