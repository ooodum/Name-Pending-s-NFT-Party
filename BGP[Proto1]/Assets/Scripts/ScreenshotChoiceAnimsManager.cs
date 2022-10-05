using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScreenshotChoiceAnimsManager : MonoBehaviour
{
    [SerializeField] Image NFTsprite;
    [SerializeField] Image container;
    [SerializeField] TextMeshProUGUI title;

    [SerializeField] ShopManager shopManager;

    [SerializeField] ScreenshotPlayerChoiceSelection SPCS;

    public string lastAnim;
    public int choiceContainerID;

    public int numOfNFTsShown;

    public Vector3 inPos;
    public Vector3 outPos;

    public void SetInvisAnim() {
        shopManager.AnimImageTransparency(NFTsprite, 1, 0, 0, 0);
        shopManager.AnimImageTransparency(container, 1, 0, 0, 0);
        shopManager.AnimTextTransparency(title, 1, 0, 0, 0);
    }

    public void AnimIn() {
        if (lastAnim != "AnimIn") {
            lastAnim = "AnimIn";

            CancelAnim();
            LeanTween.move(gameObject.GetComponent<RectTransform>(), inPos, 1f).setDelay(0.2f * choiceContainerID).setEaseOutCirc().setOnComplete(SPCS.ActivateChoiceSelection);
            LeanTween.scale(gameObject.GetComponent<RectTransform>(), Vector3.one, 0.5f).setDelay(0.1f).setEaseOutElastic();
            shopManager.AnimImageTransparency(NFTsprite, 0, 1, 0.25f, 0.5f + (0.05f * choiceContainerID));
            shopManager.AnimImageTransparency(container, 0, 1, 0.4f, 0.5f + (0.05f * choiceContainerID));
            shopManager.AnimTextTransparency(title, 0, 1, 0.25f, 0.75f + (0.05f * choiceContainerID));
        }
    }
    public void AnimOut() {
        if (lastAnim != "AnimOut") {
            lastAnim = "AnimOut";

            CancelAnim();
            LeanTween.move(gameObject.GetComponent<RectTransform>(), outPos, 1f).setDelay(0.2f * choiceContainerID).setEaseOutCirc();
            shopManager.AnimImageTransparency(NFTsprite, 1, 0, 0.05f, 0 + (0.025f * choiceContainerID));
            shopManager.AnimImageTransparency(container, 1, 0, 0.05f, 0f + (0.025f * choiceContainerID));
            shopManager.AnimTextTransparency(title, 1, 0, 0.05f, 0 + (0.025f * choiceContainerID));
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    void CancelAnim() {
        LeanTween.cancel(NFTsprite.gameObject);
        LeanTween.cancel(container.gameObject);
        LeanTween.cancel(title.gameObject);
    }
}
