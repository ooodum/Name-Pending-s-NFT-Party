using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenshotChoiceManager : MonoBehaviour
{
    [SerializeField] private Image NFTImage;
    [SerializeField] private TextMeshProUGUI title;

    [SerializeField] private NFTManager NFTManager;

    [SerializeField] private ScreenshotPoolManagerConnected SPMC;

    public NFTInfo thisNFT;
    public int thisNFTIndex;
    

    public void RefreshScreenshotSelection(GameObject other) {
        int tempRandom = Random.Range(0, SPMC.tempNFTList.Count);
        int tempIndex = 0;
        thisNFT = SPMC.tempNFTList[tempRandom];
        NFTImage.sprite = thisNFT.sprite;
        title.text = $"{thisNFT.collection} #0{thisNFT.ID}";
        foreach(NFTInfo child in NFTManager.NFTList) {
            if (child.collection == thisNFT.collection && child.ID == thisNFT.ID) {
                thisNFTIndex = tempIndex;
                break;
            } else tempIndex++;
        }
        SPMC.tempNFTList.RemoveAt(tempRandom);
    }

    
}
