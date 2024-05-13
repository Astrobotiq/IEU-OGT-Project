using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //this class will do general things for our plant. hold information (it will probably have a scriptable object in it). 
    public PlantSO plantInfo;
    public SpriteRenderer plant;
    GridManager gridManager;

    private void Awake()
    {
        GameObject go = GameObject.FindWithTag("GridManager");
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(5);
    }

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
        Debug.Log("Plant geldi: " + plantSO.name);
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
        plant.sprite = sprite;
    }
}
