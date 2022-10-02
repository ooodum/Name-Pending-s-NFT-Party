using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETHManager : MonoBehaviour
{
    //Reference the board and the ETH prefab
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject ETH;

    //Create a list that stores all the "normal" tiles (Not a shop tile, not a spawn tile)
    List<GameObject> listOfTiles = new List<GameObject>();
    void Start() {
        //Add every normal tile to the listOfTiles
        foreach(Transform child in board.transform) {
            if(child.name == "Tile") {
                listOfTiles.Add(child.gameObject);
            }
        }
        //Spawn 10 ETH pickups
        SpawnETH(10);
    }

    void Update() {
        
    }

    //Function to randomly spawn ETH throughout the map
    public void SpawnETH(int amount) {
        //Loops through "amount" times
        for (int i = 0; i < amount; i++) {
            //Generates a random number from 0 to the amount of normal tiles there are minus one
            int tileIndex = Random.Range(0, listOfTiles.Count);
            //If the tile that it picks is empty, spawn an ETH at that tile. otherwise, repeat the process again
            if (listOfTiles[tileIndex].GetComponent<Tile>().currentPiece == null) {
                Instantiate(ETH, listOfTiles[tileIndex].transform.position, ETH.transform.rotation);
            } else i--;
        }
    }
}
