using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSelection : MonoBehaviour {
    public string lastAnim;
    public int choiceContainerID;
    public NFTInfo thisNFT;
    public int thisNFTIndex;
    public float price;

    [SerializeField] public ShopPool shopPool;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private TextMeshProUGUI priceTag;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image NFTImage;
    [SerializeField] private Image container;
    [SerializeField] private PlayerChoiceSelection PCS;
    [SerializeField] private NFTManager NFTManager;

    private Vector3 inPos;
    private Vector3 outPos;
    void Start() {
        inPos = new Vector3(-380 + ((choiceContainerID - 1) * 380), -85, 0);
        outPos = Vector3.right * (-380 + ((choiceContainerID - 1) * 380));
        shopManager.AnimImageTransparency(NFTImage, 1, 0, 0, 0);
        shopManager.AnimImageTransparency(container, 1, 0, 0, 0);
        shopManager.AnimTextTransparency(priceTag, 1, 0, 0, 0);
        shopManager.AnimTextTransparency(title, 1, 0, 0, 0);

        LeanTween.move(gameObject.GetComponent<RectTransform>(), outPos, 0);
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), Vector3.one, 0);
    }

    public void AnimIn() {
        if (lastAnim != "AnimIn") {
            lastAnim = "AnimIn";

            CancelAnim();

            LeanTween.move(gameObject.GetComponent<RectTransform>(), inPos, 1f).setDelay(0.1f * choiceContainerID).setEaseOutCirc().setOnComplete(PCS.ActivateChoiceSelection);
            LeanTween.scale(gameObject.GetComponent<RectTransform>(), Vector3.one, 0.5f).setEaseOutElastic();
            shopManager.AnimImageTransparency(NFTImage, 0, 1, 0.25f, 0.5f + (0.05f * choiceContainerID));
            shopManager.AnimImageTransparency(container, 0, 1, 0.4f, 0.5f + (0.05f * choiceContainerID));
            shopManager.AnimTextTransparency(priceTag, 0, 1, 0.25f, 0.75f + (0.05f * choiceContainerID));
            shopManager.AnimTextTransparency(title, 0, 1, 0.25f, 0.75f + (0.05f * choiceContainerID));
        }
        
    }

    public void AnimOut() {
        if (lastAnim != "AnimOut") {
            lastAnim = "AnimOut";

            CancelAnim();

            LeanTween.move(gameObject.GetComponent<RectTransform>(), outPos, 1f).setEaseOutCirc().setDelay(0.025f * choiceContainerID);
            LeanTween.scale(gameObject.GetComponent<RectTransform>(), Vector3.one, 0.5f).setEaseOutElastic();

            shopManager.AnimImageTransparency(NFTImage, 1, 0, 0.05f, 0 + (0.025f * choiceContainerID));
            shopManager.AnimImageTransparency(container, 1, 0, 0.05f, 0f + (0.025f * choiceContainerID));
            shopManager.AnimTextTransparency(priceTag, 1, 0, 0.05f, 0 + (0.025f * choiceContainerID));
            shopManager.AnimTextTransparency(title, 1, 0, 0.05f, 0 + (0.025f * choiceContainerID));
        }
        
    }

    void CancelAnim() {
        LeanTween.cancel(gameObject);
        LeanTween.cancel(NFTImage.gameObject);
        LeanTween.cancel(container.gameObject);
        LeanTween.cancel(priceTag.gameObject);
        LeanTween.cancel(title.gameObject);
    }

    public void RefreshShopSelection() {
        int tempRandom = Random.Range(0, shopPool.availableNFTs.Count);
        int tempIndex = 0;
        thisNFT = shopPool.availableNFTs[tempRandom];
        NFTImage.sprite = thisNFT.sprite;
        title.text = $"{thisNFT.collection} #0{thisNFT.ID}";
        price = setNFTPrice(thisNFT.collection);
        priceTag.text = $"{price} ETH";
        foreach(NFTInfo child in NFTManager.NFTList) {
            if (child.collection == thisNFT.collection && child.ID == thisNFT.ID) {
                thisNFTIndex = tempIndex;
                break;
            } else tempIndex++;
        }
        shopPool.availableNFTs.RemoveAt(tempRandom);
        transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0);
    }

    private float setNFTPrice(string collectionName) {
        switch (collectionName) {
            case "Dissimulation":
                return Mathf.Round((Random.Range(0.5f, 0.8f)) * 100) / 100;
            case "Exodus":
                return Mathf.Round((Random.Range(1.2f, 2.5f)) * 100) / 100;
            case "Mouse Squadron":
                return Mathf.Round((Random.Range(0.6f, 0.9f)) * 100) / 100;
            case "Nendoroiiids":
                return Mathf.Round((Random.Range(0.4f, 1.3f)) * 100) / 100;
            case "Uncle Bob":
                return Mathf.Round((Random.Range(1, 2f)) * 100) / 100;
            default:
                return 0;

        }
    }
}
