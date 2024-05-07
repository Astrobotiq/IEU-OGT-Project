using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableControl : MonoBehaviour
{
    public delegate void PlantReadyEventHandler(GameObject plant);

    public static event PlantReadyEventHandler OnPlantReady;

    public string type;
    public bool isRipe = false;
    public float growthTime;
    public bool isSeeded = false;

    void Start()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    void Update()
    {
        if (isSeeded)
        {
            Invoke("Prepared", growthTime);
        }

    }

    private void Prepared()
    {
        isRipe = true;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetComponent<TimeBar>().GetSlider().SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player") && !isRipe)
        {
            transform.GetComponent<TimeBar>().GetSlider().SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            transform.GetComponent<TimeBar>().GetSlider().SetActive(false);
        }
    }
}