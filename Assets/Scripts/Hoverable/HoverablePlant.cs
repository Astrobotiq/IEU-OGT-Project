using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverablePlant : _Hoverable
{
    TooltipManager tooltipManager;
    [SerializeField] Plant plant;
    string plantHeader;
    string plantContent;

    private void Awake()
    {
        GameObject tooltipGO = GameObject.FindWithTag("ToolTip");
        tooltipManager = tooltipGO.GetComponent<TooltipManager>();
        plant = GetComponent<Plant>();
        if (plant != null)
        {
            if(plant.getHeader()!= null || plant.getContent() != null)
            {
                plantHeader = plant.getHeader();
                plantContent = plant.getContent();
            }
        }
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
