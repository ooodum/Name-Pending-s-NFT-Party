using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPool : MonoBehaviour {
    [SerializeField] private NFTManager nftManager;
    public List<NFTInfo> availableNFTs = new List<NFTInfo>();

    [SerializeField] private ShopSelection container1;
    [SerializeField] private ShopSelection container2;
    [SerializeField] private ShopSelection container3;

    public void RefreshNFTShopPool() {
        availableNFTs.Clear();
        foreach(NFTInfo child in nftManager.NFTList) {
            if (child.owner == null) {
                availableNFTs.Add(child);
            }
        }
        container1.RefreshShopSelection();
        container2.RefreshShopSelection();
        container3.RefreshShopSelection();
    }
}
