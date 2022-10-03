using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animInOut : MonoBehaviour {
    //References all four players' player controller
    [SerializeField] private PlayerController p1Text;
    [SerializeField] private PlayerController p2Text;
    [SerializeField] private PlayerController p3Text;
    [SerializeField] private PlayerController p4Text;

    //Two positions; when the textbox is visible, and when the textbox isn't (I figured hardcoded values here were okay because they're part of the canvas)
    private Vector3 outPos = new Vector3(258, 100, 0);
    private Vector3 inPos = new Vector3(-218, 100, 0);

    //Gets the last animation
    private string lastAnim = null;

    void Update() {
        //If any player enables the sidebar:
        if (p1Text.sideTextNeeded || p2Text.sideTextNeeded || p3Text.sideTextNeeded || p4Text.sideTextNeeded) {
            AnimIn();
            lastAnim = "AnimIn";
        } else {
            AnimOut();
            lastAnim = "AnimOut";
        }
    }
    public void AnimIn() {
        if (lastAnim != "AnimIn") {
            LeanTween.cancel(gameObject);
            LeanTween.move(gameObject.GetComponent<RectTransform>(), outPos, 1f).setEaseOutCirc();
        }
    }
    public void AnimOut() {
        if (lastAnim != "AnimOut") {
            LeanTween.cancel(gameObject);
            LeanTween.move(gameObject.GetComponent<RectTransform>(), inPos, 1f).setEaseOutCirc();
        }
    }
}
