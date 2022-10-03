using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInOut : MonoBehaviour {
    //References all four players' player controller
    [SerializeField] private PlayerController p1Text;
    [SerializeField] private PlayerController p2Text;
    [SerializeField] private PlayerController p3Text;
    [SerializeField] private PlayerController p4Text;

    //Two positions; when the textbox is visible, and when the textbox isn't (I figured hardcoded values here were okay because they're part of the canvas)
    private Vector3 outPos = new Vector3(258, 302, 0);
    private Vector3 inPos = new Vector3(-218, 302, 0);

    void Update() {
        //If any player enables the sidebar:
        if (p1Text.sideTextNeeded || p2Text.sideTextNeeded || p3Text.sideTextNeeded || p4Text.sideTextNeeded) AnimIn();
        else AnimOut();
    }
    void AnimIn() {
        LeanTween.moveX(gameObject.GetComponent<RectTransform>(), outPos.x, 0.5f);
        print(LeanTween.moveX(gameObject.GetComponent<RectTransform>(), outPos.x, 0.5f));
    }
    void AnimOut() {
        LeanTween.moveX(gameObject.GetComponent<RectTransform>(), inPos.x, 0.5f);
    }
}
