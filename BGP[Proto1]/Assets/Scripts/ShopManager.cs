using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour {
    private Vector3 upPos = new Vector3(-150,125,0);
    private Vector3 ETHPos = new Vector3(0, -300, 0);
    public string lastAnim = null;
    public bool darkWebOn = false;

    [SerializeField] private Image bg;
    [SerializeField] private Image ETHLogo;
    [SerializeField] private TextMeshProUGUI ETHText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private ChoiceAnimsManager shopSelection;

    void Start(){
        AnimImageTransparency(bg, 1, 0, 0f, 0);
        AnimImageTransparency(ETHLogo, 1, 0, 0f, 0);
        AnimTextTransparency(ETHText, 1, 0, 0, 0);
        AnimTextTransparency(titleText, 1, 0, 0, 0);
        LeanTween.move(gameObject.GetComponent<RectTransform>(), upPos, 0);
        LeanTween.move(ETHLogo.transform.parent.GetComponent<RectTransform>(), ETHPos * 0.8f, 0);
        LeanTween.move(titleText.GetComponent<RectTransform>(), Vector3.up * 21, 0);
    }

    public void ShopAnimIn() {
        if (lastAnim != "ShopAnimIn") {
            lastAnim = "ShopAnimIn";
            cancelAnims();

            LeanTween.move(gameObject.GetComponent<RectTransform>(), Vector3.zero + new Vector3 (upPos.x, 25, 0), 0.75f).setEaseOutCirc();
            LeanTween.move(ETHLogo.transform.parent.GetComponent<RectTransform>(), ETHPos, 1f).setEaseOutCirc().setDelay(0.2f);
            LeanTween.move(titleText.GetComponent<RectTransform>(), Vector3.zero, 1f).setEaseOutCirc().setDelay(0.25f);
            AnimImageTransparency(bg, 0, 1, 0.25f, 0);
            AnimImageTransparency(ETHLogo, 0, 1, 0.25f, 0.3f);
            AnimTextTransparency(ETHText, 0, 1, 0.25f, 0.3f);
            AnimTextTransparency(titleText, 0, 1, 0.25f, 0.25f);

            shopSelection.AnimIn();
        }
    }
    public void ShopAnimOut() {
        if (lastAnim != "ShopAnimOut") {
            lastAnim = "ShopAnimOut";
            cancelAnims();

            LeanTween.move(gameObject.GetComponent<RectTransform>(), upPos, 0.75f).setEaseOutCirc().setDelay(0.2f);
            LeanTween.move(ETHLogo.transform.parent.GetComponent<RectTransform>(), ETHPos * 0.8f, 1f).setDelay(0.1f).setEaseOutCirc();
            LeanTween.move(titleText.GetComponent<RectTransform>(), Vector3.up * 21, 1f).setEaseOutCirc().setDelay(0.1f);
            AnimImageTransparency(bg, 1, 0, 0.25f, 0.2f);
            AnimImageTransparency(ETHLogo, 1, 0, 0.1f, 0.1f);
            AnimTextTransparency(ETHText, 1, 0, 0.1f, 0.1f);
            AnimTextTransparency(titleText, 1, 0, 0.1f, 0.1f);

            shopSelection.AnimOut();
        }
    }

    public void AnimImageTransparency(Image image, float start, float end, float value, float delay) {
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
    void cancelAnims() {
        LeanTween.cancel(gameObject);
        LeanTween.cancel(bg.gameObject);
        LeanTween.cancel(ETHLogo.gameObject);
        LeanTween.cancel(ETHText.gameObject);
        LeanTween.cancel(ETHText.transform.parent.gameObject);
        LeanTween.cancel(titleText.gameObject);
    }
}
