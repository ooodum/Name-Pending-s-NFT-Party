using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotPlayerChoiceSelection : MonoBehaviour {
    [SerializeField] private RectTransform container1;
    [SerializeField] private RectTransform container2;
    [SerializeField] private NFTManager NFTManager;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private ScreenshotManager screenshotManager;

    public bool canSelect = false;
    private int currentChoice;
    private int lastChoice;

    public int numOfNFTsShown;

    private float duration = 0.6f;
    private Vector3 scale = new Vector3(1, 1, 1);

    void Start() {
        container1.GetChild(3).gameObject.SetActive(false);
        container2.GetChild(3).gameObject.SetActive(false);
    }

    void Update() {
        if (canSelect) {
            switch (currentChoice) {
                case 1:
                    if (lastChoice != 1) {
                        lastChoice = 1;
                        container1.GetChild(3).gameObject.SetActive(true);
                        container2.GetChild(3).gameObject.SetActive(false);

                        LeanTween.cancel(container1.gameObject);
                        LeanTween.cancel(container2.gameObject);

                        LeanTween.scale(container1, scale * 1.2f, duration).setEaseOutElastic();
                        LeanTween.scale(container2, scale, duration).setEaseOutElastic();
                    }
                    break;
                case 2:
                    if (lastChoice != 2) {
                        lastChoice = 2;
                        container2.GetChild(3).gameObject.SetActive(true);
                        container1.GetChild(3).gameObject.SetActive(false);

                        LeanTween.cancel(container1.gameObject);
                        LeanTween.cancel(container2.gameObject);

                        LeanTween.scale(container2, scale * 1.2f, duration).setEaseOutElastic();
                        LeanTween.scale(container1, scale, duration).setEaseOutElastic();
                    }
                    break;
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                switch (currentChoice) {
                    case 1:
                        NFTManager.NFTList[container1.GetComponent<ScreenshotChoiceManager>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];
                        screenshotManager.CloseScreenshotWindow();
                        break;
                    case 2:
                        NFTManager.NFTList[container2.GetComponent<ScreenshotChoiceManager>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];
                        screenshotManager.CloseScreenshotWindow();
                        break;
                }
                turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerInventoryManager>().SetInventory();
                canSelect = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            currentChoice--;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            currentChoice++;
        }
        currentChoice = Mathf.Clamp(currentChoice, 1, numOfNFTsShown);
    }
    public void ActivateChoiceSelection() {
        LeanTween.cancel(container1);
        LeanTween.cancel(container2);
        canSelect = true;
        currentChoice = 1;
}
}
