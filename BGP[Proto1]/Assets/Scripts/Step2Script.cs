using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Step2Script : MonoBehaviour {
    [SerializeField] AnimsManager animsManager;
    [SerializeField] TextMeshProUGUI hate;
    [SerializeField] MenuSelect menuSelect;

    void Start() {
        animsManager.AnimTextTransparency(hate, 0, 0, 0, 0);
    }

    public void AnimIn() {
        animsManager.AnimTextTransparency(hate, 0, 1, 1, 0);
        LeanTween.scaleZ(gameObject, 1, 2).setOnComplete(AnimOut);
    }

    void AnimOut() {
        animsManager.AnimTextTransparency(hate, 1, 0, 1, 0);
        LeanTween.scaleZ(gameObject, 1, 1.5f).setOnComplete(callNext);
    }

    void callNext() {
        menuSelect.AnimIn();
    }
}
