using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour {
    [SerializeField] ShopManager shopManager;

    [SerializeField] PlayerController player1;
    [SerializeField] PlayerController player2;
    [SerializeField] PlayerController player3;
    [SerializeField] PlayerController player4;

    [SerializeField] Image GameOverScreen;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI desc;
    [SerializeField] TextMeshProUGUI control;

    bool gameEnded;

    private void Start() {
        shopManager.AnimImageTransparency(GameOverScreen, 0, 0, 0, 0);
        shopManager.AnimTextTransparency(title, 0, 0, 0, 0);
        shopManager.AnimTextTransparency(desc, 0, 0, 0, 0);
        shopManager.AnimTextTransparency(control, 0, 0, 0, 0);
        LeanTween.moveY(GameOverScreen.gameObject.GetComponent<RectTransform>(), 100, 2).setEaseOutCirc();
    }
    public void EndGame(int num) {
        shopManager.shopOpen = false;
        player1.turnPhase = -1;
        player2.turnPhase = -1;
        player3.turnPhase = -1;
        player4.turnPhase = -1;

        shopManager.AnimImageTransparency(GameOverScreen, 0, 1, 0.5f, 0);
        shopManager.AnimTextTransparency(title, 0, 1, 0.5f, 0);
        shopManager.AnimTextTransparency(desc, 0, 1, 0.5f, 0);
        shopManager.AnimTextTransparency(control, 0, 1, 0.5f, 0);

        LeanTween.moveY(GameOverScreen.gameObject.GetComponent<RectTransform>(), 0, 2).setEaseOutCirc().setOnComplete(setEnd);
        title.text = $"Player {num} wins!";
        
    }
    void setEnd() {
        gameEnded = true;
    }
    private void Update() {
        if (gameEnded) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                SceneLoader.ReturnToMenu();
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }
    }
}
