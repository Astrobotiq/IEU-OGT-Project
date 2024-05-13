using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public GameObject[,] indexList;
    public Tilemap tilemap;
    public RuleTile ruleTile;
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        indexList = new GameObject[size, size];
        tileInýtializer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tileInýtializer()
    {
        for(int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                tilemap.SetTile(new Vector3Int(i,j),ruleTile);
                indexList[i, j] = null;
            }
        }
    }

    public void setPlantObject(Vector2Int index,GameObject go)
    {
        indexList[index.x, index.y] = go;
    }

    public bool isPlanted(Vector2Int index)
    {
        if (indexList[index.x, index.y] == null)
        {
            return false;
        }
        return true;
    }

    public void setGrass(Vector2Int pos)
    {
        
        
    }


}
