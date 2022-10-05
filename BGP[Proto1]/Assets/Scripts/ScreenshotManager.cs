using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScreenshotManager : MonoBehaviour {
    [SerializeField] private NFTManager NFTManager;

    [SerializeField] private Image overlay;
    [SerializeField] private Image popup;
    [SerializeField] private Image container1;
    [SerializeField] private Image container2;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI subtitle;

    [SerializeField] private ScreenshotPlayerChoiceSelection SPCS;
    [SerializeField] private ScreenshotPoolManagerConnected SPMC;

    [SerializeField] private TurnManager turnManager;
    public string lastAnim;
    public bool isActive = false;
    void Awake() {
        overlay.gameObject.SetActive(true);
        popup.gameObject.SetActive(true);

        AnimImageTransparency(overlay, 1, 0, 0, 0);
        AnimImageTransparency(popup, 1, 0, 0, 0);
        AnimImageTransparency(container1, 1, 0, 0, 0);
        AnimImageTransparency(container2, 1, 0, 0, 0);
        AnimTextTransparency(title, 1, 0, 0, 0);
        AnimTextTransparency(subtitle, 1, 0, 0, 0);
        LeanTween.scale(popup.gameObject.GetComponent<RectTransform>(), Vector2.one * 0.5f, 0);
        container1.GetComponent<ScreenshotChoiceAnimsManager>().SetInvisAnim();
        container2.GetComponent<ScreenshotChoiceAnimsManager>().SetInvisAnim();
    }

    void Update() {
        
    }
    public void ScreenshotPlayer(GameObject other, GameObject player) {
        if (lastAnim != "SS") {
            lastAnim = "SS";
            StopAllCoroutines();
            SPMC.tempNFTList.Clear();
            cancelAnims();
            isActive = true;
            switch (SPMC.checkScreenshotPool(other)) {
                case 0:
                    player.GetComponent<PlayerController>().turnPhase = 4;
                    break;
                case 1:
                    container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().inPos = Vector3.up * -85;
                    container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().outPos = Vector3.zero;

                    AnimImageTransparency(overlay, 1, 0, 2f, 0);
                    AnimImageTransparency(popup, 0, 1, 0.5f, 0.5f);
                    AnimTextTransparency(title, 0, 1, 1, 0.75f);
                    AnimTextTransparency(subtitle, 0, 1, 1, 0.75f);
                    LeanTween.scale(popup.gameObject.GetComponent<RectTransform>(), Vector2.one, 0.75f).setDelay(0.5f).setEaseInOutBack();
                    container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().AnimIn();
                    SPCS.numOfNFTsShown = 1;

                    container1.gameObject.GetComponent<ScreenshotChoiceManager>().RefreshScreenshotSelection(other);
                    subtitle.text = $"You screenshot Player {other.GetComponent<PlayerController>().playerInt}'s NFT! You acquired the following NFT:";
                    break;
                case int n when (n >= 2):
                    container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().inPos = new Vector3(-222, -85, 0);
                    container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().outPos = Vector3.right * (-222);
                    container2.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().inPos = new Vector3(222, -85, 0);
                    container2.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().outPos = Vector3.right * (222);


                    AnimImageTransparency(overlay, 1, 0, 2f, 0);
                    AnimImageTransparency(popup, 0, 1, 0.5f, 0.5f);
                    AnimTextTransparency(title, 0, 1, 1, 0.75f);
                    AnimTextTransparency(subtitle, 0, 1, 1, 0.75f);
                    LeanTween.scale(popup.gameObject.GetComponent<RectTransform>(), Vector2.one, 0.75f).setDelay(0.5f).setEaseInOutBack();
                    container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().AnimIn();
                    container2.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().AnimIn();
                    SPCS.numOfNFTsShown = 2;
                    container1.gameObject.GetComponent<ScreenshotChoiceManager>().RefreshScreenshotSelection(other);
                    container2.gameObject.GetComponent<ScreenshotChoiceManager>().RefreshScreenshotSelection(other);

                    subtitle.text = $"You screenshot Player {other.GetComponent<PlayerController>().playerInt}'s NFT! Steal one of the following:";
                    break;
            }
        }
    }

    public void CloseScreenshotWindow() {
        if (lastAnim != "Close") {
            lastAnim = "Close";
        }
        turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerController>().turnPhase = 12;
        AnimImageTransparency(popup, 1, 0, 0.5f, 0);
        AnimTextTransparency(title, 1, 0, 0.5f, 0);
        AnimTextTransparency(subtitle, 1, 0, 0.5f, 0);
        LeanTween.scale(popup.gameObject.GetComponent<RectTransform>(), Vector2.one * 0.5f, 0.75f).setEaseInOutBack();
        container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().AnimOut();
        container2.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().AnimOut();
        isActive = false;
    }
    void cancelAnims() {
        LeanTween.cancel(overlay.gameObject);
        LeanTween.cancel(popup.gameObject);
        LeanTween.cancel(container1.gameObject);
        LeanTween.cancel(container2.gameObject);
        LeanTween.cancel(title.gameObject);
        LeanTween.cancel(subtitle.gameObject);
    }

    void AnimImageTransparency(Image image, float start, float end, float value, float delay) {
        LeanTween.value(image.gameObject, start, end, value).setDelay(delay).setOnUpdate((value) => {
            Color c = image.color;
            c.a = value;
            image.color = c;
        });
    }

    public void AnimTextTransparency(TextMeshProUGUI text, float start, float end, float value, float delay) {
        LeanTween.value(text.gameObject, start, end, value).setDelay(delay).setOnUpdate((value) => {
            Color c = text.faceColor;
            c.a = value;
            text.faceColor = c;
        });
    }
}
