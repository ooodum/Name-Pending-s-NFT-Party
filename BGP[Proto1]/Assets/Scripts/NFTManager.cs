using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NFTInfo {
    public GameObject owner;
    public int ID;
    public string collection;
    public Sprite sprite;
}
public class NFTManager : MonoBehaviour
{
    [SerializeField] private LoadNFTSprites imageManager;
    //Create arrays for each NFT Collection
    public List<NFTInfo> NFTList = new List<NFTInfo>();
    void Awake() {
        NFTList.Add(new NFTInfo { ID = 0, collection = "Dissimulation", sprite = imageManager.Dis0 });
        NFTList.Add(new NFTInfo { ID = 1, collection = "Dissimulation", sprite = imageManager.Dis1 });
        NFTList.Add(new NFTInfo { ID = 2, collection = "Dissimulation", sprite = imageManager.Dis2 });
        NFTList.Add(new NFTInfo { ID = 3, collection = "Dissimulation", sprite = imageManager.Dis3 });
        NFTList.Add(new NFTInfo { ID = 4, collection = "Dissimulation", sprite = imageManager.Dis4 });
        NFTList.Add(new NFTInfo { ID = 5, collection = "Dissimulation", sprite = imageManager.Dis5 });
        NFTList.Add(new NFTInfo { ID = 6, collection = "Dissimulation", sprite = imageManager.Dis6 });

        NFTList.Add(new NFTInfo { ID = 0, collection = "Exodus", sprite = imageManager.Ex0 });
        NFTList.Add(new NFTInfo { ID = 1, collection = "Exodus", sprite = imageManager.Ex1 });
        NFTList.Add(new NFTInfo { ID = 2, collection = "Exodus", sprite = imageManager.Ex2 });
        NFTList.Add(new NFTInfo { ID = 3, collection = "Exodus", sprite = imageManager.Ex3 });
        NFTList.Add(new NFTInfo { ID = 4, collection = "Exodus", sprite = imageManager.Ex4 });

        NFTList.Add(new NFTInfo { ID = 0, collection = "Mouse Squadron", sprite = imageManager.MS0 });
        NFTList.Add(new NFTInfo { ID = 1, collection = "Mouse Squadron", sprite = imageManager.MS1 });
        NFTList.Add(new NFTInfo { ID = 2, collection = "Mouse Squadron", sprite = imageManager.MS2 });
        NFTList.Add(new NFTInfo { ID = 3, collection = "Mouse Squadron", sprite = imageManager.MS3 });
        NFTList.Add(new NFTInfo { ID = 4, collection = "Mouse Squadron", sprite = imageManager.MS4 });
        NFTList.Add(new NFTInfo { ID = 5, collection = "Mouse Squadron", sprite = imageManager.MS5 });

        NFTList.Add(new NFTInfo { ID = 0, collection = "Nendoroiiids", sprite = imageManager.Nen0 });
        NFTList.Add(new NFTInfo { ID = 1, collection = "Nendoroiiids", sprite = imageManager.Nen1 });
        NFTList.Add(new NFTInfo { ID = 2, collection = "Nendoroiiids", sprite = imageManager.Nen2 });
        NFTList.Add(new NFTInfo { ID = 3, collection = "Nendoroiiids", sprite = imageManager.Nen3 });
        NFTList.Add(new NFTInfo { ID = 4, collection = "Nendoroiiids", sprite = imageManager.Nen4 });
        NFTList.Add(new NFTInfo { ID = 5, collection = "Nendoroiiids", sprite = imageManager.Nen5 });
        NFTList.Add(new NFTInfo { ID = 6, collection = "Nendoroiiids", sprite = imageManager.Nen6 });

        NFTList.Add(new NFTInfo { ID = 0, collection = "Uncle Bob", sprite = imageManager.UB0 });
        NFTList.Add(new NFTInfo { ID = 1, collection = "Uncle Bob", sprite = imageManager.UB1 });
        NFTList.Add(new NFTInfo { ID = 2, collection = "Uncle Bob", sprite = imageManager.UB2 });
        NFTList.Add(new NFTInfo { ID = 3, collection = "Uncle Bob", sprite = imageManager.UB3 });
        NFTList.Add(new NFTInfo { ID = 4, collection = "Uncle Bob", sprite = imageManager.UB4 });
    }

    void Update() {
        
    }
}
