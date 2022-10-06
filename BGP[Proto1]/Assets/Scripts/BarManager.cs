using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarManager : MonoBehaviour {
    [SerializeField] private RectTransform bar1;
    [SerializeField] private RectTransform bar2;
    [SerializeField] private Camera cam;
    public void BlackBars() {
        bar1.anchoredPosition = Vector2.zero + (Vector2.up * bar1.rect.height * 1.5f);
        bar2.anchoredPosition = Vector2.zero - (Vector2.up * bar2.rect.height * 1.5f);

        LeanTween.move(bar1, Vector2.up * bar1.rect.height / 2, 2).setEaseInOutQuint().setDestroyOnComplete(true);
        LeanTween.move(bar2, -Vector2.up * bar2.rect.height / 2, 2).setEaseInOutQuint().setDestroyOnComplete(true).setOnComplete(loadGame);
    }

    void loadGame() {
        cam.backgroundColor = bar1.gameObject.GetComponent<Image>().color;
        SceneLoader.Load();
    }
}
