using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CredsScript : MonoBehaviour {
    [SerializeField] private AnimsManager animsManager;

    [SerializeField] private TextMeshProUGUI creds;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private RectTransform pressEsc;

    [SerializeField] private MenuSelect menu;

    Vector2 credsPos;
    Vector2 descPos;
    Vector2 escPos;

    bool allowReturn;
    void Start() {
        credsPos = creds.gameObject.GetComponent<RectTransform>().anchoredPosition;
        descPos = desc.gameObject.GetComponent<RectTransform>().anchoredPosition;
        escPos = pressEsc.gameObject.GetComponent<RectTransform>().anchoredPosition;

        animsManager.AnimTextTransparency(creds, 0, 0, 0, 0);
        animsManager.AnimTextTransparency(desc, 0, 0, 0, 0);
    }

    void Update() {
        if (allowReturn) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                allowReturn = false;
                AnimOut();
                menu.AnimIn();
            }
        }
    }

    public void AnimIn() {
        animsManager.AnimTextTransparency(creds, 0, 1, 0.3f, 0.7f);
        animsManager.AnimTextTransparency(desc, 0, 1, 0.3f, 0.85f);

        LeanTween.moveY(creds.gameObject.GetComponent<RectTransform>(), -386, 1.5f).setEaseOutCirc().setDelay(0.7f);
        LeanTween.moveX(desc.gameObject.GetComponent<RectTransform>(), 326, 1.5f).setEaseOutCirc().setDelay(0.85f);
        LeanTween.moveY(pressEsc.gameObject.GetComponent<RectTransform>(), 75, 1.5f).setEaseOutCirc().setDelay(0.85f);

        LeanTween.scaleZ(gameObject, 1, 0.5f).setOnComplete(AllowReturn);
    }

    void AnimOut() {
        LeanTween.cancel(creds.gameObject);
        LeanTween.cancel(desc.gameObject);
        LeanTween.cancel(pressEsc.gameObject);

        allowReturn = false;
        animsManager.AnimTextTransparency(creds, 1, 0, 0.3f, 0.15f);
        animsManager.AnimTextTransparency(desc, 1, 0, 0.3f, 0);

        LeanTween.move(creds.gameObject.GetComponent<RectTransform>(), credsPos, 1f).setEaseOutCirc().setDelay(0.1f);
        LeanTween.move(desc.gameObject.GetComponent<RectTransform>(), descPos, 1f).setEaseOutCirc().setDelay(0);
        LeanTween.move(pressEsc.gameObject.GetComponent<RectTransform>(), escPos, 1f).setEaseOutCirc().setDelay(0.2f);
    }

    void AllowReturn() {
        allowReturn = true;
    }
}
