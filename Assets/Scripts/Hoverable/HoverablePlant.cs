using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverablePlant : _Hoverable
{
    [SerializeField] GameObject hoverUI;
    public override void onHover()
    {
        if (hoverUI != null)
        {
            hoverUI.SetActive(true);
        }
    }

    public override void onHoverEnd()
    {
        if(hoverUI != null)
        {
            hoverUI.SetActive(false);
        }
    }
}
