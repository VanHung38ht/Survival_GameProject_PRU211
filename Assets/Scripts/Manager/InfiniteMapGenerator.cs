using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] groundTiles;

    private Dictionary<Vector3Int, TileBase> tiles = new Dictionary<Vector3Int, TileBase>();

  
    private void Awake()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int x = -100; x < 100; x++)
        {
            for (int y = -100; y < 100; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                TileBase tile = groundTiles[Random.Range(0, groundTiles.Length)];
                tilemap.SetTile(tilePos, tile);
                tiles.Add(tilePos, tile);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3Int playerTilePos = tilemap.WorldToCell(transform.position);

        if (!tiles.ContainsKey(playerTilePos))
        {
            TileBase tile = groundTiles[Random.Range(0, groundTiles.Length)];
            tilemap.SetTile(playerTilePos, tile);
            tiles.Add(playerTilePos, tile);
        }
    }
}
