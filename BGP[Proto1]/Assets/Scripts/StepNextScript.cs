using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StepNextScript : MonoBehaviour {
    [SerializeField] private AnimsManager animsManager;

    [SerializeField] private TextMeshProUGUI partyText;
    [SerializeField] private Image arrows;
    [SerializeField] private Image mouse;
    [SerializeField] private Image check;
    [SerializeField] private Image redX;

    [SerializeField] private BarManager bars;

    private void Start() {
        animsManager.AnimTextTransparency(partyText, 0, 0, 0, 0);
        animsManager.AnimImageTransparency(arrows, 0, 0, 0, 0);
        animsManager.AnimImageTransparency(mouse, 0, 0, 0, 0);
        animsManager.AnimImageTransparency(check, 0, 0, 0, 0);
        animsManager.AnimImageTransparency(redX, 0, 0, 0, 0);
    }

    public void AnimIn() {
        animsManager.AnimTextTransparency(partyText, 0, 1, 1, 1);
        animsManager.AnimImageTransparency(arrows, 0, 1, 1, 1);
        animsManager.AnimImageTransparency(mouse, 0, 1, 1, 1);
        animsManager.AnimImageTransparency(check, 0, 1, 1, 1);
        animsManager.AnimImageTransparency(redX, 0, 1, 1, 1);

        LeanTween.scaleZ(gameObject, 1, 3).setOnComplete(AnimOut);
    }

    void AnimOut() {
        animsManager.AnimTextTransparency(partyText, 1, 0, 1, 0);
        animsManager.AnimImageTransparency(arrows, 1, 0, 1, 0);
        animsManager.AnimImageTransparency(mouse, 1, 0, 1, 0);
        animsManager.AnimImageTransparency(check, 1, 0, 1, 0);
        animsManager.AnimImageTransparency(redX, 1, 0, 1, 0);

        LeanTween.scaleZ(gameObject, 0, 1).setOnComplete(CallBars);
    }

    void CallBars() {
        bars.BlackBars();
    }
}
