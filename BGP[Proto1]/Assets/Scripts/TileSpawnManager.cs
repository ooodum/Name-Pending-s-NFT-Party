using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    //Reference the tile and the player
    public GameObject tile;
    public GameObject player;

    //Gets the size of the tile
    public int xSize;
    public int ySize;
    public float tileSize;
    void Start(){
        tile.transform.localScale = new Vector2(tileSize, tileSize);
        player.transform.localScale = tile.transform.localScale / 2;
        for (int i = (ySize - 1) / 2; i > ((-(ySize - 1)) / 2) - 1; i--) {
            for (int j = (-(xSize - 1)) / 2; j < ((xSize - 1) / 2) + 1; j++) {
                Instantiate(tile, new Vector3(player.transform.position.x + j * tileSize, player.transform.position.y + i * tileSize, 0), tile.transform.rotation);
            }
        }
    }

    void Update(){
        
    }
}
