using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWebPool : MonoBehaviour
{
    public List<NFTInfo> darkPool = new List<NFTInfo>();

    [SerializeField] private ScreenshotPoolManager SPM;
    [SerializeField] private TurnManager turnManager;
    public List<NFTInfo> availableNFTs = new List<NFTInfo>();

    [SerializeField] private DarkWebIndividualChoiceSelection container1;
    [SerializeField] private DarkWebIndividualChoiceSelection container2;
    [SerializeField] private DarkWebIndividualChoiceSelection container3;

    public void RefreshDarkWebPool() {
        availableNFTs.Clear();
        foreach (NFTInfo child in SPM.availableNFTs) {
            if ((child.owner != null) && (child.owner.GetComponent<PlayerController>().playerInt != turnManager.turn)) {
                availableNFTs.Add(child);
            }
        }
        container1.RefreshDarkWebSelection();
        container2.RefreshDarkWebSelection();
        container3.RefreshDarkWebSelection();
    }
}
