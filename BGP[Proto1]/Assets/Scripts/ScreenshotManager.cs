using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenshotManager : MonoBehaviour {
    [SerializeField] private NFTManager NFTManager;

    [SerializeField] private Image overlay;
    [SerializeField] private Image popup;
    [SerializeField] private Image container1;
    [SerializeField] private Image container2;
    private string lastAnim;
    void Awake() {
        overlay.gameObject.SetActive(true);
        popup.gameObject.SetActive(true);

        AnimImageTransparency(overlay, 1, 0, 0, 0);
        AnimImageTransparency(popup, 1, 0, 0, 0);
        AnimImageTransparency(container1, 1, 0, 0, 0);
        AnimImageTransparency(container2, 1, 0, 0, 0);
        LeanTween.scale(popup.gameObject.GetComponent<RectTransform>(), Vector2.one * 0.5f, 0);
        container1.GetComponent<ScreenshotChoiceAnimsManager>().SetInvisAnim();
        container2.GetComponent<ScreenshotChoiceAnimsManager>().SetInvisAnim();
    }

    void Update() {
        
    }
    public void ScreenshotPlayer() {
        if (lastAnim != "SS") {
            lastAnim = "SS";

            cancelAnims();

            AnimImageTransparency(overlay, 1, 0, 2f, 0);

            AnimImageTransparency(popup, 0, 1, 0.5f, 0.5f);
            LeanTween.scale(popup.gameObject.GetComponent<RectTransform>(), Vector2.one, 0.75f).setDelay(0.5f).setEaseInOutBack();
            container1.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().AnimIn();
            container2.gameObject.GetComponent<ScreenshotChoiceAnimsManager>().AnimIn();
        }
    }

    void cancelAnims() {
        LeanTween.cancel(overlay.gameObject);
        LeanTween.cancel(popup.gameObject);
        LeanTween.cancel(container1.gameObject);
        LeanTween.cancel(container2.gameObject);
    }

    void AnimImageTransparency(Image image, float start, float end, float value, float delay) {
        LeanTween.value(image.gameObject, start, end, value).setDelay(delay).setOnUpdate((value) => {
            Color c = image.color;
            c.a = value;
            image.color = c;
        });
    }
}
