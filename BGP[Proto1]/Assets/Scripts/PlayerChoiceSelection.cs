using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceSelection : MonoBehaviour {
    public bool canSelect;
    private int currentChoice;
    private int lastChoice;
    private float duration = 0.6f;
    private Vector3 scale = new Vector3(1, 1, 1);

    [SerializeField] RectTransform container1;
    [SerializeField] RectTransform container2;
    [SerializeField] RectTransform container3;
    [SerializeField] TurnManager turnManager;
    [SerializeField] NFTManager NFTManager;

    private bool sold1;
    private bool sold2;
    private bool sold3;
    private void Start() {
        if (container1.GetChild(5).gameObject.activeSelf) LeanTween.scale(container1.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();
        if (container2.GetChild(5).gameObject.activeSelf) LeanTween.scale(container2.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();
        if (container3.GetChild(5).gameObject.activeSelf) LeanTween.scale(container2.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();
    }
    private void Update() {
        if (canSelect) {
            switch (currentChoice) {
                case 1:
                    if (lastChoice != 1) {
                        lastChoice = 1;
                        if (!sold1) container1.GetChild(4).gameObject.SetActive(true); else container1.GetChild(5).gameObject.SetActive(true);
                        container2.GetChild(4).gameObject.SetActive(false);
                        container3.GetChild(4).gameObject.SetActive(false);

                        LeanTween.cancel(container1.gameObject);
                        LeanTween.cancel(container2.gameObject);
                        LeanTween.cancel(container3.gameObject);

                        LeanTween.scale(container1, scale * 1.2f, duration).setEaseOutElastic();
                        LeanTween.scale(container2, scale, duration).setEaseOutElastic();
                        LeanTween.scale(container3, scale, duration).setEaseOutElastic();
                    }
                    
                    break;
                case 2:
                    if (lastChoice != 2) {
                        lastChoice = 2;
                        if (!sold2) container2.GetChild(4).gameObject.SetActive(true); else container2.GetChild(5).gameObject.SetActive(true);
                        container1.GetChild(4).gameObject.SetActive(false);
                        container3.GetChild(4).gameObject.SetActive(false);

                        LeanTween.cancel(container1.gameObject);
                        LeanTween.cancel(container2.gameObject);
                        LeanTween.cancel(container3.gameObject);

                        LeanTween.scale(container2, scale * 1.2f, duration).setEaseOutElastic();
                        LeanTween.scale(container1, scale, duration).setEaseOutElastic();
                        LeanTween.scale(container3, scale, duration).setEaseOutElastic();
                    }
                    break;
                case 3:
                    if (lastChoice != 3) {
                        lastChoice = 3;
                        if (!sold3) container3.GetChild(4).gameObject.SetActive(true); else container3.GetChild(5).gameObject.SetActive(true);
                        container1.GetChild(4).gameObject.SetActive(false);
                        container2.GetChild(4).gameObject.SetActive(false);

                        LeanTween.cancel(container1.gameObject);
                        LeanTween.cancel(container2.gameObject);
                        LeanTween.cancel(container3.gameObject);

                        LeanTween.scale(container3, scale * 1.2f, duration).setEaseOutElastic();
                        LeanTween.scale(container1, scale, duration).setEaseOutElastic();
                        LeanTween.scale(container2, scale, duration).setEaseOutElastic();
                    }
                    break;
            }
            
            if (Input.GetKeyDown(KeyCode.Space)) {
                canSelect = false;
                lastChoice = 0;
                currentChoice = 0;

                LeanTween.cancel(container1);
                LeanTween.cancel(container2);
                LeanTween.cancel(container3);

                if (container1.GetChild(5).gameObject.activeSelf) LeanTween.scale(container1.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();
                if (container1.GetChild(5).gameObject.activeSelf) LeanTween.scale(container2.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();
                if (container1.GetChild(5).gameObject.activeSelf) LeanTween.scale(container2.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();

                container1.GetChild(4).gameObject.SetActive(false);
                container2.GetChild(4).gameObject.SetActive(false);
                container3.GetChild(4).gameObject.SetActive(false);

                container1.GetChild(5).gameObject.SetActive(false);
                container2.GetChild(5).gameObject.SetActive(false);
                container3.GetChild(5).gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                switch (currentChoice) {
                    case 1:
                        if (!sold1) {
                            if (turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH >= container1.GetComponent<ShopSelection>().price) {
                                turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH -= (container1.GetComponent<ShopSelection>().price);

                                NFTManager.NFTList[container1.GetComponent<ShopSelection>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];

                                container1.GetChild(4).gameObject.SetActive(false);
                                container1.GetChild(5).gameObject.SetActive(true);

                                container1.GetChild(1).GetComponent<Image>().color = new Color(1, 0.76f, 0.76f);

                                sold1 = true;
                            } else {
                                LeanTween.cancel(container1.gameObject);
                                LeanTween.move(container1.GetComponent<RectTransform>(), container1.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                            }
                        } else {
                            LeanTween.cancel(container1.gameObject);
                            LeanTween.move(container1.GetComponent<RectTransform>(), container1.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                        }
                        break;
                    case 2:
                        if (!sold2) {
                            if (turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH >= container2.GetComponent<ShopSelection>().price) {
                                turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH -= (container2.GetComponent<ShopSelection>().price);

                                NFTManager.NFTList[container2.GetComponent<ShopSelection>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];

                                container2.GetChild(4).gameObject.SetActive(false);
                                container2.GetChild(5).gameObject.SetActive(true);

                                container2.GetChild(1).GetComponent<Image>().color = new Color(1, 0.76f, 0.76f);

                                sold2 = true;
                            } else {
                                LeanTween.cancel(container2.gameObject);
                                LeanTween.move(container2.GetComponent<RectTransform>(), container2.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                            }
                        } else {
                            LeanTween.cancel(container2.gameObject);
                            LeanTween.move(container2.GetComponent<RectTransform>(), container2.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();

                        }
                        break;  
                    case 3:
                        if (!sold3) {
                            if (turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH >= container3.GetComponent<ShopSelection>().price) {
                                turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH -= (container3.GetComponent<ShopSelection>().price);

                                NFTManager.NFTList[container3.GetComponent<ShopSelection>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];

                                container3.GetChild(4).gameObject.SetActive(false);
                                container3.GetChild(5).gameObject.SetActive(true);

                                container3.GetChild(1).GetComponent<Image>().color = new Color(1, 0.76f, 0.76f);

                                sold3 = true;
                            } else {
                                LeanTween.cancel(container3.gameObject);
                                LeanTween.move(container3.GetComponent<RectTransform>(), container3.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                            }
                        } else {
                            LeanTween.cancel(container3.gameObject);
                            LeanTween.move(container3.GetComponent<RectTransform>(), container3.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                        }
                        break;
                }
                turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerInventoryManager>().SetInventory();
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                currentChoice--;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                currentChoice++;
            }
            currentChoice = Mathf.Clamp(currentChoice, 1, 3);
        }
    }

    public void ActivateChoiceSelection() {
        LeanTween.cancel(container1);
        LeanTween.cancel(container2);
        LeanTween.cancel(container3);   
        canSelect = true;
        currentChoice = 2;
        if (NFTManager.NFTList[container1.GetComponent<ShopSelection>().thisNFTIndex].owner == turnManager.PlayerChildren[turnManager.turn - 1]) {
            container1.GetChild(5).gameObject.SetActive(true);
            LeanTween.scale(container1.GetChild(5).GetComponent<RectTransform>(), Vector3.one, 0.5f).setEaseOutElastic();
            sold1 = true;
        } else sold1 = false;
        if (NFTManager.NFTList[container2.GetComponent<ShopSelection>().thisNFTIndex].owner == turnManager.PlayerChildren[turnManager.turn - 1]) {
            container2.GetChild(5).gameObject.SetActive(true);
            LeanTween.scale(container2.GetChild(5).GetComponent<RectTransform>(), Vector3.one, 0.5f).setEaseOutElastic();
            sold2 = true;
        } else sold2 = false;
        if (NFTManager.NFTList[container3.GetComponent<ShopSelection>().thisNFTIndex].owner == turnManager.PlayerChildren[turnManager.turn - 1]) {
            container3.GetChild(5).gameObject.SetActive(true);
            LeanTween.scale(container3.GetChild(5).GetComponent<RectTransform>(), Vector3.one, 0.5f).setEaseOutElastic();
            sold3 = true;
        } else sold3 = false;
    }
}
