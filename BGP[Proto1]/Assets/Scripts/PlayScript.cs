using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayScript : MonoBehaviour {
    [SerializeField] AnimsManager animsManager;

    [SerializeField] private TextMeshProUGUI askPlayers;
    [SerializeField] private TextMeshProUGUI num;
    [SerializeField] private TextMeshProUGUI pressEsc;
    [SerializeField] private TextMeshProUGUI enterText;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    [SerializeField] private RectTransform enterBox;
    [SerializeField] private GameObject enterFull;

    [SerializeField] private MenuSelect menu;
    [SerializeField] private StepNextScript SNS;

    Vector2 askPlayersPos;
    Vector2 escPos;

    int numOfPlayers;
    bool canSelect;

    string lastLeftAnim;
    string lastRightAnim;
    string lastEnterAnim;
    public int PlayerCount { get; set; }

    void Awake() {
        PlayerCount = PlayerPrefs.GetInt("numKey");
    }
    void Start() {
        escPos = pressEsc.gameObject.GetComponent<RectTransform>().anchoredPosition;
        askPlayersPos = askPlayers.gameObject.GetComponent<RectTransform>().anchoredPosition;

        animsManager.AnimTextTransparency(askPlayers, 0, 0, 0, 0);
        animsManager.AnimTextTransparency(num, 0, 0, 0, 0);
        animsManager.AnimTextTransparency(enterText, 0, 0, 0, 0);
        animsManager.AnimImageTransparency(left.gameObject.GetComponent<Image>(), 0, 0, 0, 0);
        animsManager.AnimImageTransparency(right.gameObject.GetComponent<Image>(), 0, 0, 0, 0);
        animsManager.AnimImageTransparency(enterBox.gameObject.GetComponent<Image>(), 0, 0, 0, 0);
    }

    void Update() {
        if (canSelect) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                if (lastLeftAnim != "Down") {
                    lastLeftAnim = "Down";
                    LeanTween.cancel(left.gameObject);
                    LeanTween.scale(left, Vector2.one * 0.8f, 0.1f).setEaseOutCirc();
                    numOfPlayers--;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) {
                if (lastLeftAnim != "Up") {
                    lastLeftAnim = "Up";
                    LeanTween.cancel(left.gameObject);
                    LeanTween.scale(left, Vector2.one, 0.1f).setEaseOutCirc();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                if (lastRightAnim != "Down") {
                    lastRightAnim = "Down";
                    LeanTween.cancel(right.gameObject);
                    LeanTween.scale(right, Vector2.one * 0.8f, 0.1f).setEaseOutCirc();
                    numOfPlayers++;
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {
                if (lastRightAnim != "Up") {
                    lastRightAnim = "Up";
                    LeanTween.cancel(right.gameObject);
                    LeanTween.scale(right, Vector2.one, 0.1f).setEaseOutCirc();
                }
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (lastEnterAnim != "Down") {
                    lastEnterAnim = "Down";
                    LeanTween.cancel(enterFull.gameObject);
                    LeanTween.scale(enterFull, Vector2.one * 0.8f, 0.3f).setEaseOutCirc();
                }
            }
            if (Input.GetKeyUp(KeyCode.Return)) {
                if (lastEnterAnim != "Up") {
                    lastEnterAnim = "Up";
                    LeanTween.cancel(enterFull.gameObject);
                    LeanTween.scale(enterFull, Vector2.one, 0.3f).setEaseOutCirc();
                    canSelect = false;
                    LeanTween.scaleZ(gameObject, 1, 0.5f).setOnComplete(AnimOut);

                    PlayerPrefs.SetInt("numKey", numOfPlayers);

                    SNS.AnimIn();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                canSelect = false;
                AnimOut();
                menu.AnimIn();
            }
            numOfPlayers = Mathf.Clamp(numOfPlayers, 2, 4);
            num.text = $"{numOfPlayers}";
        }
    }

    public void AnimIn() {
        animsManager.AnimTextTransparency(askPlayers, 0, 1, 0.3f, 0.5f);
        animsManager.AnimTextTransparency(num, 0, 1, 0.3f, 0.75f);
        animsManager.AnimImageTransparency(left.gameObject.GetComponent<Image>(), 0, 1, 0.3f, 0.75f);
        animsManager.AnimImageTransparency(right.gameObject.GetComponent<Image>(), 0, 1, 0.3f, 0.75f);
        animsManager.AnimTextTransparency(enterText, 0, 1, 0.3f, 1.2f);
        animsManager.AnimImageTransparency(enterBox.gameObject.GetComponent<Image>(), 0, 1, 0.3f, 1.2f);

        LeanTween.moveY(askPlayers.gameObject.GetComponent<RectTransform>(), 301, 1f).setEaseOutCirc().setOnComplete(enableSelect);
        LeanTween.moveY(pressEsc.gameObject.GetComponent<RectTransform>(), 75, 1.5f).setEaseOutCirc().setDelay(0.85f);
    }

    void AnimOut() {
        LeanTween.cancel(askPlayers.gameObject);
        LeanTween.cancel(num.gameObject);
        LeanTween.cancel(pressEsc.gameObject);
        LeanTween.cancel(enterText.gameObject);
        LeanTween.cancel(left.gameObject);
        LeanTween.cancel(right.gameObject);
        LeanTween.cancel(enterBox.gameObject);
        LeanTween.cancel(enterFull.gameObject);

        animsManager.AnimTextTransparency(askPlayers, 1, 0, 0.3f, 0f);
        animsManager.AnimTextTransparency(num, 1, 0, 0.3f, 0);
        animsManager.AnimImageTransparency(left.gameObject.GetComponent<Image>(), 1, 0, 0.3f, 0);
        animsManager.AnimImageTransparency(right.gameObject.GetComponent<Image>(), 1, 0, 0.3f, 0);
        animsManager.AnimTextTransparency(enterText, 1, 0, 0.3f, 0);
        animsManager.AnimImageTransparency(enterBox.gameObject.GetComponent<Image>(), 1, 0, 0.3f, 0);

        LeanTween.move(askPlayers.gameObject.GetComponent<RectTransform>(), askPlayersPos, 1f).setEaseOutCirc();
        LeanTween.move(pressEsc.gameObject.GetComponent<RectTransform>(), escPos, 1f).setEaseOutCirc();
    }

    void enableSelect() {
        canSelect = true;
    }
}
