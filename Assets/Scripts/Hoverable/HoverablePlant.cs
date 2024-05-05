using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverablePlant : _Hoverable
{
    [SerializeField] TooltipManager tooltipManager;
    [SerializeField] Plant plant;
    string plantHeader;
    string plantContent;

    private void Awake()
    {
        plant = GetComponent<Plant>();
        plantHeader = plant.getHeader();
        plantContent = plant.getContent();
    }
    public override void onHover()
    {
        
        if (tooltipManager != null)
        {
            
            tooltipManager.show(plantContent,transform.position,plantHeader);
        }
    }

    public override void onHoverEnd()
    {
        if(tooltipManager != null)
        {
            tooltipManager.hide();
        }
    }
}
