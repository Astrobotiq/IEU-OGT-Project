using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Items/Wand/Groundshaker")]
public class GroundShaker : WandSO
{
    public RuleTile TileSoil;
    public RuleTile TileGrass;
    GameObject tileGO;
    Tilemap tilemap;

    /*public override void onUse(Vector3 playerPos, Vector3 mousePos)
    {
        tileGO = GameObject.FindWithTag("Soil");
        if (tileGO == null)
        {
            Debug.Log("Cannot find tileGO");
        }
        tilemap = tileGO.GetComponent<Tilemap>();
        if (tileGO == null)
        {
            Debug.Log("Cannot find tilemap");
        }

        Vector3Int pos = new Vector3Int((int)(Mathf.Floor(mousePos.x)), (int)Mathf.Floor(mousePos.y));
        Debug.Log("tilePos: " + pos);
        tilemap.SetTile(pos,Tile);
    }*/

    public override void onUse(Vector3 playerPos, Vector3 mousePos)
    {
        tileGO = GameObject.FindWithTag("Soil");
        if (tileGO == null)
        {
            Debug.Log("Cannot find tileGO");
        }
        tilemap = tileGO.GetComponent<Tilemap>();
        if (tileGO == null)
        {
            Debug.Log("Cannot find tilemap");
        }

        Vector3Int pos = new Vector3Int((int)(Mathf.Floor(mousePos.x)), (int)Mathf.Floor(mousePos.y));
        if (tilemap.GetTile(pos) == TileGrass)
        {
            Debug.Log("tilePos: " + pos);
            tilemap.SetTile(pos, TileSoil);
            GameObject gameObject = Instantiate(TileSoil.m_TilingRules[0].m_GameObject);
        }
        
    }
}
