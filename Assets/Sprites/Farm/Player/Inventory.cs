using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum VegetableType
    {
        Carrot,
        Corn,
        Eggplant,
        Pumpkin,
        Tomato,
        Turnip
    }

    public GameObject[] prefabs;
    private GameObject _container;
    public int count = 0;

    public Dictionary<VegetableType, List<GameObject>> vegetableInventory =
        new Dictionary<VegetableType, List<GameObject>>();

    private void Awake()
    {
        foreach (VegetableType type in Enum.GetValues(typeof(VegetableType)))
        {
            vegetableInventory.Add(type, new List<GameObject>());
        }

        _container = GameObject.Find("PlantContainer");
    }
    public void AddVegetable(GameObject plant)
    {
        if (plant == null)
        {
            Debug.LogError("Invalid plant object.");
            return;
        }

        VegetableType type;
        if (Enum.TryParse(plant.GetComponent<VegetableControl>().type, out type) &&
            vegetableInventory.ContainsKey(type))
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                if (prefabs[i].GetComponent<VegetableControl>().type == plant.GetComponent<VegetableControl>().type)
                {
                    GameObject tomato = Instantiate(prefabs[i]);
                    GameObject tomato1 = Instantiate(prefabs[i]);
                    tomato.transform.SetParent(_container.transform);
                    tomato1.transform.SetParent(_container.transform);
                    tomato1.SetActive(false);
                    tomato.SetActive(false);
                    vegetableInventory[type].Add(tomato);
                    vegetableInventory[type].Add(tomato1); 
                    break;
                }
            }
            
            count += 2; 
            Debug.Log($"Added {plant.GetComponent<VegetableControl>().type} (2x)");
        }
        else
        {
            Debug.LogError($"Invalid vegetable type: {plant.tag}");
        }
    }




    public bool UseVegetable(string typeString)
    {
        VegetableType type;
        if (Enum.TryParse(typeString, true, out type) && vegetableInventory[type].Count > 0)
        {
            vegetableInventory[type].RemoveAt(0);
            return true;
        }

        return false;
    }

    public GameObject GetPlantPrefab(VegetableType type)
    {
        if (vegetableInventory.ContainsKey(type) && vegetableInventory[type].Count > 0)
        {
            Debug.Log("HALOOO");
            return vegetableInventory[type][0]; 
        }
        return null;
    }
}