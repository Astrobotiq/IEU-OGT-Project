using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "ItemInfo", menuName = "Items/Wand/ItemThrower")]
public class ItemThrower : WandSO
{
    public PlantSO plantSO;
    public override void onUse(Vector3 playerPos, Vector3 mousePos)
    {
        GameObject tileGO = GameObject.FindWithTag("Soil");
        Tilemap tilemap = tileGO.GetComponent<Tilemap>();
        Vector3Int tilePos = tilemap.WorldToCell(mousePos);
        TileBase tile = tilemap.GetTile(tilePos);
        if (tile != null)
        {
            Plant plant = tileGO.GetComponent<Plant>();
            if (plant != null)
            {
                plant.setPlant(plantSO);
            }
        }
    }
}
