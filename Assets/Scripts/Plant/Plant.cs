using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //this class will do general things for our plant. hold information (it will probably have a scriptable object in it). 
    public PlantSO plantInfo;
    public GameObject plant;

    public string getHeader()
    {
        return plantInfo.name;
    }

    public string getContent()
    {
        string temp = plantInfo.description + "\n" +
                      "Time to Grow: " + plantInfo.timeToGrow;

        return temp;
    }

    public void setPlant(PlantSO plantSO)
    {
        if(plantInfo != null)
        {
            Debug.Log("This tile already planted");
        }
        else
        {
            plantInfo = plantSO;
            showPlant(plantInfo.getSprite(0));
        }
    }

    public void showPlant(Sprite sprite)
    {
        plant.SetActive(true);
        plant.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
