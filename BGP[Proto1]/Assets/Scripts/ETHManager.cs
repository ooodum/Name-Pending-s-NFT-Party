using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETHManager : MonoBehaviour
{
    //Reference the board and the ETH prefab
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject ETH;
    public int numOfETH;

    //Create a list that stores all the "normal" tiles (Not a shop tile, not a spawn tile)
    List<GameObject> listOfTiles = new List<GameObject>();
    void Start() {
        ReferenceTiles();
        //Spawn 10 ETH pickups
        SpawnETH(20);
    }

    void Update() {
        if (numOfETH == 0) {
            SpawnETH(20);
        }
    }

    //Function to randomly spawn ETH throughout the map
    public void SpawnETH(int amount) {
        numOfETH = amount;
        //Loops through "amount" times
        for (int i = 0; i < amount; i++) {
            //Generates a random number from 0 to the amount of normal tiles there are minus one
            int tileIndex = Random.Range(0, listOfTiles.Count);
            //Creates an ETH pickup at the random tile's position, then removes that tile from the list
            Instantiate(ETH, listOfTiles[tileIndex].transform.position, ETH.transform.rotation);
            listOfTiles.RemoveAt(tileIndex);
        }
        //Clear the list and create it again
        listOfTiles.Clear();
        ReferenceTiles();
    }

    void ReferenceTiles() {
        //Add every normal tile to the listOfTiles
        foreach (Transform child in board.transform) {
            if (child.name == "Tile") {
                listOfTiles.Add(child.gameObject);
            }
        }
    }

}
