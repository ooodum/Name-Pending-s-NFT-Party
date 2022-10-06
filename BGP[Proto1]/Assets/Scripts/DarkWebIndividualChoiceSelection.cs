using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DarkWebIndividualChoiceSelection : MonoBehaviour
{
    [SerializeField] DarkWebPool DWP;
    [SerializeField] NFTManager NFTManager;

    [SerializeField] private TextMeshProUGUI priceTag;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image NFTImage;
    [SerializeField] private Image container;

    public string lastAnim;
    public int choiceContainerID;
    public NFTInfo thisNFT;
    public int thisNFTIndex;
    public float price;
    public Color thisBG;

    private void Start() {
        thisBG = transform.GetChild(1).GetComponent<Image>().color;
    }

    public void RefreshDarkWebSelection() {
        int tempRandom = Random.Range(0, DWP.availableNFTs.Count);
        int tempIndex = 0;
        if (DWP.availableNFTs.Count != 0) {
            thisNFT = DWP.availableNFTs[tempRandom];
            NFTImage.color = new Color(1, 1, 1, 0);
            NFTImage.sprite = thisNFT.sprite;
            title.text = $"{thisNFT.collection} #0{thisNFT.ID}";
            price = setNFTPrice(thisNFT.collection);
            priceTag.text = $"{price} ETH";
            foreach (NFTInfo child in NFTManager.NFTList) {
                if (child.collection == thisNFT.collection && child.ID == thisNFT.ID) {
                    thisNFTIndex = tempIndex;
                    break;
                } else tempIndex++;
            }
            DWP.availableNFTs.RemoveAt(tempRandom);
        } else if (DWP.availableNFTs.Count == 0) {
            NFTImage.color = new Color(0, 0, 0, 0);
            price = Mathf.Infinity;
            title.text = "NOT AVAILABLE";
            priceTag.text = $">>><<<";
        }
    }

    private float setNFTPrice(string collectionName) {
        switch (collectionName) {
            case "Dissimulation":
                return 3 * (Mathf.Round((Random.Range(0.5f, 0.8f)) * 100) / 100);
            case "Exodus":
                return 3 * (Mathf.Round((Random.Range(1.2f, 2.5f)) * 100) / 100);
            case "Mouse Squadron":
                return 3 * (Mathf.Round((Random.Range(0.6f, 0.9f)) * 100) / 100);
            case "Nendoroiiids":
                return 3 * (Mathf.Round((Random.Range(0.4f, 1.3f)) * 100) / 100);
            case "Uncle Bob":
                return 3 * (Mathf.Round((Random.Range(1, 2f)) * 100) / 100);
            default:
                return Mathf.Infinity;

        }
    }
}
