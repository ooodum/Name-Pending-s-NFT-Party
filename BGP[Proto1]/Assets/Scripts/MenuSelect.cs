using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSelect : MonoBehaviour {
    [SerializeField] AnimsManager animsManager;

    [SerializeField] Image logo;
    [SerializeField] TextMeshProUGUI play;
    [SerializeField] TextMeshProUGUI creds;

    [SerializeField] RectTransform pressEnter;
    [SerializeField] RectTransform selectArrow;

    [SerializeField] PlayScript playButton;
    [SerializeField] CredsScript credsButton;

    Vector2 logoPos;
    Vector2 playPos;
    Vector2 credsPos;
    Vector2 arrowPos;
    Vector2 enterPos;

    int currentSelect;
    bool canSelect;
    string lastAnim;
    int tweenID;

    void Start() {
        logoPos = logo.gameObject.GetComponent<RectTransform>().anchoredPosition;
        playPos = play.gameObject.GetComponent<RectTransform>().anchoredPosition;
        credsPos = creds.gameObject.GetComponent<RectTransform>().anchoredPosition;
        arrowPos = new Vector2(60, playPos.y);
        enterPos = pressEnter.anchoredPosition;

        animsManager.AnimImageTransparency(logo, 0, 0, 0, 0);
        animsManager.AnimImageTransparency(selectArrow.gameObject.GetComponent<Image>(), 0, 0, 0, 0);
        animsManager.AnimTextTransparency(play, 0, 0, 0, 0);
        animsManager.AnimTextTransparency(creds, 0, 0, 0, 0);

        selectArrow.anchoredPosition = arrowPos;
    }

    public void AnimIn() {
        animsManager.AnimImageTransparency(logo, 0, 1, 0.5f, 0.1f);
        animsManager.AnimTextTransparency(play, 0, 1, 0.5f, 0.4f);
        animsManager.AnimTextTransparency(creds, 0, 1, 0.5f, 0.5f);

        LeanTween.move(logo.gameObject.GetComponent<RectTransform>(), new Vector3(442, 140, 0), 1).setEaseInOutBack();
        LeanTween.move(play.gameObject.GetComponent<RectTransform>(), new Vector3(341, 374, 0), 1).setEaseInOutBack().setDelay(0.5f).setOnComplete(allowSelect);
        LeanTween.move(creds.gameObject.GetComponent<RectTransform>(), new Vector3(341, 211, 0), 1).setEaseInOutBack().setDelay(0.6f);

        LeanTween.scaleZ(gameObject, 1, 0.75f).setOnComplete(InitializeSelect);

        currentSelect = 1;
        lastAnim = null;
    }

    void InitializeSelect() {
        animsManager.AnimImageTransparency(selectArrow.gameObject.GetComponent<Image>(), 0, 1, 0.2f, 0.25f);
        LeanTween.move(selectArrow, new Vector3(130, play.gameObject.GetComponent<RectTransform>().anchoredPosition.y, 0), 0.6f).setDelay(0.2f).setEaseOutCirc().setOnComplete(BackAndForth);
    }

    void BackAndForth() {
        LeanTween.moveX(selectArrow, selectArrow.anchoredPosition.x - 20, 0.75f).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(pressEnter, 75, 1).setEaseOutCirc();
    }

    void allowSelect() {
        canSelect = true;
    }

    void Update() {
        if (canSelect) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                AnimUp();
                currentSelect--;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
                AnimDown();
                currentSelect++;
            }
            currentSelect = Mathf.Clamp(currentSelect, 1, 2);

            if (Input.GetKeyDown(KeyCode.Return)) {
                switch (currentSelect) {
                    case 1:
                        AnimOut();
                        playButton.AnimIn();
                        canSelect = false;
                        break;
                    case 2:
                        AnimOut();
                        credsButton.AnimIn();
                        canSelect = false;
                        break;
                }
            }
        }
    }

    void AnimUp() {
        if (lastAnim != "Up") {
            lastAnim = "Up";
            LeanTween.cancel(tweenID);
            tweenID = LeanTween.moveY(selectArrow, play.gameObject.GetComponent<RectTransform>().anchoredPosition.y, 0.5f).setEaseOutElastic().id;
        }
    }
    void AnimDown() {
        if (lastAnim != "Down") {
            lastAnim = "Down";
            LeanTween.cancel(tweenID);
            tweenID = LeanTween.moveY(selectArrow, creds.gameObject.GetComponent<RectTransform>().anchoredPosition.y, 0.5f).setEaseOutElastic().id;
        }
    }

    void AnimOut() {
        LeanTween.cancelAll();
        LeanTween.move(logo.gameObject.GetComponent<RectTransform>(), logoPos, 0.5f).setEaseOutBack();
        LeanTween.move(play.gameObject.GetComponent<RectTransform>(), playPos, 0.5f).setEaseOutBack().setDelay(0.1f);
        LeanTween.move(creds.gameObject.GetComponent<RectTransform>(), credsPos, 0.5f).setEaseOutBack().setDelay(0.2f);
        LeanTween.moveX(selectArrow, arrowPos.x, 0.5f).setEaseOutBack().setOnComplete(setArrowPos);
        LeanTween.move(pressEnter, enterPos, 0.5f).setEaseOutBack();

        animsManager.AnimImageTransparency(logo, 1, 0, 0.3f, 0);
        animsManager.AnimImageTransparency(selectArrow.gameObject.GetComponent<Image>(), 1, 0, 0.3f, 0);
        animsManager.AnimTextTransparency(play, 1, 0, 0.3f, 0.1f);
        animsManager.AnimTextTransparency(creds, 1, 0, 0.3f, 0.2f);
        animsManager.AnimTextTransparency(pressEnter.gameObject.GetComponent<TextMeshProUGUI>(), 1, 0, 0.3f, 0f);
    }

    void setArrowPos() {
        selectArrow.anchoredPosition = arrowPos;
    }
}
