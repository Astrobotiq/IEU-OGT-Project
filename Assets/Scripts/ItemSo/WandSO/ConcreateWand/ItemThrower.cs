using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "ItemInfo", menuName = "Items/Wand/ItemThrower")]
public class ItemThrower : WandSO
{
    public RuleTile ruleTile;
    public PlantSO plantSO;
    public override void onUse(Vector3 playerPos, Vector3 mousePos)
    {
        GameObject go = GameObject.FindWithTag("Soil");
        Tilemap tileMap = go.GetComponent<Tilemap>();
        Vector3Int pos = new Vector3Int((int)(Mathf.Floor(mousePos.x)), (int)Mathf.Floor(mousePos.y));
        TileBase tileBase = tileMap.GetTile(pos);

        if (tileBase != null && tileBase == ruleTile)
        {
            GameObject instantiatedGameObject = Instantiate(ruleTile.m_TilingRules[0].m_GameObject, tileMap.GetCellCenterWorld(pos), Quaternion.identity);
            instantiatedGameObject.GetComponent<Plant>().setPlant(plantSO);
        }

    }
}
