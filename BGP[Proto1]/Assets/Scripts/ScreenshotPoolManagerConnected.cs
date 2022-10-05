using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotPoolManagerConnected : MonoBehaviour {
    [SerializeField] private ScreenshotPoolManager spm;
    public List<NFTInfo> tempNFTList = new List<NFTInfo>();

    public int checkScreenshotPool(GameObject other) {
        foreach (NFTInfo child in spm.availableNFTs) {
            if (child.owner.GetComponent<PlayerController>().playerInt == other.GetComponent<PlayerController>().playerInt) {
                tempNFTList.Add(child);
            }
        }
        return tempNFTList.Count;
    }
}
