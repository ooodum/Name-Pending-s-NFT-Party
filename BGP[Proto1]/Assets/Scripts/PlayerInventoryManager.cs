using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour {
    //Ints for each NFT Collection
    private int dissimulation;
    private int nendoroiiids;
    private int mouseSquadron;
    private int exodus;
    private int uncleBob;

    //Reference Inventory Bar
    [SerializeField] private GameObject inventory;

    [SerializeField] NFTManager NFTManager;
    [SerializeField] GameOver gameOver;
    public void SetInventory() {
        dissimulation = 0;
        nendoroiiids = 0;
        mouseSquadron = 0;
        exodus = 0;
        uncleBob = 0;
        foreach(NFTInfo child in NFTManager.NFTList) {
            if (child.owner == gameObject) {
                switch (child.collection) {
                    case "Dissimulation":
                        dissimulation++;
                        break;
                    case "Nendoroiiids":
                        nendoroiiids++;
                        break;
                    case "Mouse Squadron":
                        mouseSquadron++;
                        break;
                    case "Exodus":
                        exodus++;
                        break;
                    case "Uncle Bob":
                        uncleBob++;
                        break;
                }
            }
        }
        SetSquares(dissimulation, 0, 7);
        SetSquares(nendoroiiids, 1, 7);
        SetSquares(mouseSquadron, 2, 6);
        SetSquares(exodus, 3, 5);
        SetSquares(uncleBob, 4, 5);
    }

    void SetSquares(int collection, int index, int size) {
        for (int i = 0; i < size; i++) {
            if (i < collection) {
                inventory.transform.GetChild(index).GetChild(i).gameObject.SetActive(true);
            } else {
                inventory.transform.GetChild(index).GetChild(i).gameObject.SetActive(false);
            }
        }
        if (collection == size) {
            gameOver.EndGame(gameObject.GetComponent<PlayerController>().playerInt);
        }
    }
}
