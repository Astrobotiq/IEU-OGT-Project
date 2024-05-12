using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemInfo",menuName ="Items/Plant")] 
public class PlantSO : ScriptableObject
{
    public string name;
    public string description;
    public int timeToGrow;

    public GameObject meyve;
    public List<Sprite> sprites;
}
