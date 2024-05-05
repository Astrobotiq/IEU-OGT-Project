using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    private static TooltipManager instance;
    public Tooltip tooltip;

    private void Awake()
    {
        instance = this;
    }

    public void show(string content, Vector2 pos, string header = "")
    {
        instance.tooltip.setText(content,header);
        instance.tooltip.setPos(pos);
        instance.tooltip.gameObject.SetActive(true);
    }

    public void hide()
    {
        instance.tooltip.gameObject.SetActive(false);
    }

}
