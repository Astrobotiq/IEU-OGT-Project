using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlantInfo",menuName ="Plant")] 
public class PlantInfo : ScriptableObject
{
    public string name;
    public string description;
    public int timeToGrow;
}
