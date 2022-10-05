using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotPoolManager : MonoBehaviour {
    [SerializeField] NFTManager nftManager;
    public List<NFTInfo> availableNFTs = new List<NFTInfo>();

    public void RefreshScreenshotPool() {
        availableNFTs.Clear();
        foreach (NFTInfo child in nftManager.NFTList) {
            if (child.owner != null) {
                availableNFTs.Add(child);
            }
        }
    }
}
