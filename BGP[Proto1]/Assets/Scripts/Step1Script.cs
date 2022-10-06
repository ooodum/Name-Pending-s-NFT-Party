using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Step1Script : MonoBehaviour {
    [SerializeField] AnimsManager animsManager;

    [SerializeField] TextMeshProUGUI brought;
    [SerializeField] TextMeshProUGUI namePending;

    [SerializeField] Step2Script step2;

    void Start() {
        animsManager.AnimTextTransparency(brought, 0, 0, 0, 0);
        animsManager.AnimTextTransparency(namePending, 0, 0, 0, 0);
        AnimIn();
        PlayerPrefs.SetInt("numKey", 0);
    }

    void AnimIn() {
        animsManager.AnimTextTransparency(brought, 0, 1, 1, 0);
        animsManager.AnimTextTransparency(namePending, 0, 1, 1, 0);
        LeanTween.scaleZ(gameObject, 1, 2).setOnComplete(AnimOut);
    }

    void AnimOut() {
        animsManager.AnimTextTransparency(brought, 1, 0, 1, 0);
        animsManager.AnimTextTransparency(namePending, 1, 0, 1, 0);
        LeanTween.scaleZ(gameObject, 1, 1.5f).setOnComplete(callNext);
    }

    void callNext() {
        step2.AnimIn();
    }
}
