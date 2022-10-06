using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnimsManager : MonoBehaviour {
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
}
