using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupBarAnimsManager : MonoBehaviour
{
    [SerializeField] private RectTransform bar1;
    [SerializeField] private RectTransform bar2;
    void Start() {
        bar1.anchoredPosition = Vector2.zero + (Vector2.up * bar1.rect.height / 2);
        bar2.anchoredPosition = Vector2.zero - (Vector2.up * bar2.rect.height / 2);

        LeanTween.move(bar1, Vector2.up * bar1.rect.height*1.5f, 2).setDelay(1).setEaseInOutQuint().setDestroyOnComplete(true);
        LeanTween.move(bar2, -Vector2.up * bar2.rect.height*1.5f, 2).setDelay(1).setEaseInOutQuint().setDestroyOnComplete(true);
    }

    void Update() {
        
    }
}
