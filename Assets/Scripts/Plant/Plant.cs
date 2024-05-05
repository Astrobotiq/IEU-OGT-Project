using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //this class will do general things for our plant. hold information (it will probably have a scriptable object in it). 
    public PlantInfo info;

    public string getHeader()
    {
        return info.name;
    }

    public string getContent()
    {
        string temp = info.description + "\n" +
                      "Time to Grow: " + info.timeToGrow;

        return temp;
    }
}
