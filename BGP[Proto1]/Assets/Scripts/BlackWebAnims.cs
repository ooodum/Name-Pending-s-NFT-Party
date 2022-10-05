using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackWebAnims : MonoBehaviour {
    [SerializeField] ShopManager shopManager;
    [SerializeField] BlackWebChoiceSelection BWCS;
    [SerializeField] PlayerChoiceSelection PCS;

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI ETHtext;
    [SerializeField] Image ETHlogo;
    [SerializeField] TextMeshProUGUI subtitle;
    [SerializeField] RectTransform container1;
    [SerializeField] RectTransform container2;
    [SerializeField] RectTransform container3;

    private string lastAnim;

    void Start() {
        SetInvis();
    }

    public void AnimIn() {
        if (lastAnim != "AnimIn") {
            lastAnim = "AnimIn";

            CancelAnims();

            shopManager.AnimImageTransparency(gameObject.GetComponent<Image>(), 0, 1, 0.1f, 0);
            shopManager.AnimTextTransparency(title, 0, 1, 0.3f, 0.1f);
            shopManager.AnimTextTransparency(ETHtext, 0, 1, 0.3f, 0.3f);
            shopManager.AnimTextTransparency(subtitle, 0, 1, 0.3f, 0.2f);
            shopManager.AnimImageTransparency(ETHlogo, 0, 1, 0.3f, 0.3f);

            shopManager.AnimImageTransparency(container1.GetChild(0).GetComponent<Image>(), 0, 1, 0.2f, 0.35f);
            shopManager.AnimImageTransparency(container1.GetChild(1).GetComponent<Image>(), 0, 1, 0.1f, 0.35f);
            shopManager.AnimTextTransparency(container1.GetChild(2).GetComponent<TextMeshProUGUI>(), 0, 1, 0.2f, 0.35f);
            shopManager.AnimTextTransparency(container1.GetChild(3).GetComponent<TextMeshProUGUI>(), 0, 1, 0.2f, 0.35f);

            shopManager.AnimImageTransparency(container2.GetChild(0).GetComponent<Image>(), 0, 1, 0.2f, 0.4f);
            shopManager.AnimImageTransparency(container2.GetChild(1).GetComponent<Image>(), 0, 1, 0.1f, 0.4f);
            shopManager.AnimTextTransparency(container2.GetChild(2).GetComponent<TextMeshProUGUI>(), 0, 1, 0.2f, 0.4f);
            shopManager.AnimTextTransparency(container2.GetChild(3).GetComponent<TextMeshProUGUI>(), 0, 1, 0.2f, 0.4f);

            shopManager.AnimImageTransparency(container3.GetChild(0).GetComponent<Image>(), 0, 1, 0.2f, 0.45f);
            shopManager.AnimImageTransparency(container3.GetChild(1).GetComponent<Image>(), 0, 1, 0.1f, 0.45f);
            shopManager.AnimTextTransparency(container3.GetChild(2).GetComponent<TextMeshProUGUI>(), 0, 1, 0.2f, 0.45f);
            shopManager.AnimTextTransparency(container3.GetChild(3).GetComponent<TextMeshProUGUI>(), 0, 1, 0.2f, 0.45f);

            PCS.canSelect = false;
            LeanTween.scale(gameObject.GetComponent<RectTransform>(), Vector2.one, 0.75f).setOnComplete(TurnOnDarkWeb);
        }
    }

    public void AnimOut() {
        if (lastAnim != "AnimOut") {
            lastAnim = "AnimOut";

            CancelAnims();

            shopManager.AnimImageTransparency(gameObject.GetComponent<Image>(), 1, 0, 0.1f, 0.35f);
            shopManager.AnimTextTransparency(title, 1, 0, 0.1f, 0.2f);
            shopManager.AnimTextTransparency(ETHtext, 1, 0, 0.1f, 0);
            shopManager.AnimTextTransparency(subtitle, 1, 0, 0.1f, 0.1f);
            shopManager.AnimImageTransparency(ETHlogo, 1, 0, 0.1f, 0);

            shopManager.AnimImageTransparency(container1.GetChild(0).GetComponent<Image>(), 1, 0, 0.1f, 0);
            shopManager.AnimImageTransparency(container1.GetChild(1).GetComponent<Image>(), 1, 0, 0.2f, 0);
            shopManager.AnimTextTransparency(container1.GetChild(2).GetComponent<TextMeshProUGUI>(), 1, 0, 0.2f, 0);
            shopManager.AnimTextTransparency(container1.GetChild(3).GetComponent<TextMeshProUGUI>(), 1, 0, 0.2f, 0);

            shopManager.AnimImageTransparency(container2.GetChild(0).GetComponent<Image>(), 1, 0, 0.1f, 0.1f);
            shopManager.AnimImageTransparency(container2.GetChild(1).GetComponent<Image>(), 1, 0, 0.2f, 0.1f);
            shopManager.AnimTextTransparency(container2.GetChild(2).GetComponent<TextMeshProUGUI>(), 1, 0, 0.2f, 0.1f);
            shopManager.AnimTextTransparency(container2.GetChild(3).GetComponent<TextMeshProUGUI>(), 1, 0, 0.2f, 0.1f);

            shopManager.AnimImageTransparency(container3.GetChild(0).GetComponent<Image>(), 1, 0, 0.1f, 0.2f);
            shopManager.AnimImageTransparency(container3.GetChild(1).GetComponent<Image>(), 1, 0, 0.2f, 0.2f);
            shopManager.AnimTextTransparency(container3.GetChild(2).GetComponent<TextMeshProUGUI>(), 1, 0, 0.2f, 0.2f);
            shopManager.AnimTextTransparency(container3.GetChild(3).GetComponent<TextMeshProUGUI>(), 1, 0, 0.2f, 0.2f);

            BWCS.canSelect = false;
            LeanTween.scale(gameObject.GetComponent<RectTransform>(), Vector2.one, 0.5f).setOnComplete(TurnOffDarkWeb);
        }
    }

    void CancelAnims() {
        LeanTween.cancel(gameObject);
        LeanTween.cancel(title.gameObject);
        LeanTween.cancel(ETHtext.gameObject);
        LeanTween.cancel(subtitle.gameObject);
        LeanTween.cancel(ETHlogo.gameObject);

        LeanTween.cancel(container1.GetChild(0).gameObject);
        LeanTween.cancel(container1.GetChild(1).gameObject);
        LeanTween.cancel(container1.GetChild(2).gameObject);
        LeanTween.cancel(container1.GetChild(3).gameObject);

        LeanTween.cancel(container2.GetChild(0).gameObject);
        LeanTween.cancel(container2.GetChild(1).gameObject);
        LeanTween.cancel(container2.GetChild(2).gameObject);
        LeanTween.cancel(container2.GetChild(3).gameObject);

        LeanTween.cancel(container3.GetChild(0).gameObject);
        LeanTween.cancel(container3.GetChild(1).gameObject);
        LeanTween.cancel(container3.GetChild(2).gameObject);
        LeanTween.cancel(container3.GetChild(3).gameObject);
    }

    public void SetInvis() {
        shopManager.AnimImageTransparency(gameObject.GetComponent<Image>(), 1, 0, 0, 0);
        shopManager.AnimTextTransparency(title, 1, 0, 0, 0);   
        shopManager.AnimTextTransparency(ETHtext, 1, 0, 0, 0);   
        shopManager.AnimTextTransparency(subtitle, 1, 0, 0, 0);   
        shopManager.AnimImageTransparency(ETHlogo, 1, 0, 0, 0);

        shopManager.AnimImageTransparency(container1.GetChild(0).GetComponent<Image>(), 1, 0, 0, 0);
        shopManager.AnimImageTransparency(container1.GetChild(1).GetComponent<Image>(), 1, 0, 0, 0);
        shopManager.AnimTextTransparency(container1.GetChild(2).GetComponent<TextMeshProUGUI>(), 1, 0, 0, 0);
        shopManager.AnimTextTransparency(container1.GetChild(3).GetComponent<TextMeshProUGUI>(), 1, 0, 0, 0);

        shopManager.AnimImageTransparency(container2.GetChild(0).GetComponent<Image>(), 1, 0, 0, 0);
        shopManager.AnimImageTransparency(container2.GetChild(1).GetComponent<Image>(), 1, 0, 0, 0);
        shopManager.AnimTextTransparency(container2.GetChild(2).GetComponent<TextMeshProUGUI>(), 1, 0, 0, 0);
        shopManager.AnimTextTransparency(container2.GetChild(3).GetComponent<TextMeshProUGUI>(), 1, 0, 0, 0);

        shopManager.AnimImageTransparency(container3.GetChild(0).GetComponent<Image>(), 1, 0, 0, 0);
        shopManager.AnimImageTransparency(container3.GetChild(1).GetComponent<Image>(), 1, 0, 0, 0);
        shopManager.AnimTextTransparency(container3.GetChild(2).GetComponent<TextMeshProUGUI>(), 1, 0, 0, 0);
        shopManager.AnimTextTransparency(container3.GetChild(3).GetComponent<TextMeshProUGUI>(), 1, 0, 0, 0);
    }

    public void TurnOnDarkWeb() {
        BWCS.canSelect = true;
        shopManager.darkWebOn = true;
    }
    public void TurnOffDarkWeb() {
        PCS.canSelect = true;
        shopManager.darkWebOn = false;
    }
}
