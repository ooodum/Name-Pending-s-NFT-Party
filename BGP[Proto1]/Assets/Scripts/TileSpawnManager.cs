using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject tile;
    public GameObject player;
    public int xSize;
    public int ySize;
    void Start(){
        for (int i = (ySize - 1) / 2; i > ((-(ySize - 1)) / 2) - 1; i--) {
            for (int j = (-(xSize - 1)) / 2; j < ((xSize - 1) / 2) + 1; j++) {
                Instantiate(tile, new Vector3(player.transform.position.x + j, player.transform.position.y + i, 0), tile.transform.rotation);
            }
        }
    }

    void Update(){
        
    }
}
