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
    [SerializeField] ShopManager shopManager;
    [SerializeField] BlackWebAnims BWAnims;
    [SerializeField] BlackWebChoiceSelection BWCS;
 
    private bool sold1;
    private bool sold2;
    private bool sold3;

    Vector2 container1Pos;
    Vector2 container2Pos;
    Vector2 container3Pos;
    private void Start() {
        if (container1.GetChild(5).gameObject.activeSelf) LeanTween.scale(container1.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();
        if (container2.GetChild(5).gameObject.activeSelf) LeanTween.scale(container2.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();
        if (container3.GetChild(5).gameObject.activeSelf) LeanTween.scale(container2.GetChild(5).GetComponent<RectTransform>(), Vector3.one * 0.9f, 0).setEaseOutElastic();

        container1Pos = container1.anchoredPosition;
        container2Pos = container2.anchoredPosition;
        container3Pos = container3.anchoredPosition;
    }
    private void Update() {
        if (!shopManager.darkWebOn && shopManager.shopOpen) {
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
                if (Input.GetKeyDown(KeyCode.Return)) {
                    switch (currentChoice) {
                        case 1:
                            if (!sold1) {
                                if (turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH >= container1.GetComponent<ShopSelection>().price) {
                                    turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH = Mathf.Round((turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH - container1.GetComponent<ShopSelection>().price) * 100) / 100;

                                    NFTManager.NFTList[container1.GetComponent<ShopSelection>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];

                                    container1.GetChild(4).gameObject.SetActive(false);
                                    container1.GetChild(5).gameObject.SetActive(true);

                                    container1.GetChild(1).GetComponent<Image>().color = new Color(1, 0.76f, 0.76f);

                                    sold1 = true;
                                } else {
                                    LeanTween.cancel(container1.gameObject);
                                    container1.anchoredPosition = new Vector3(-380, -85, 0);
                                    LeanTween.move(container1.GetComponent<RectTransform>(), container1.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                                }
                            } else {
                                LeanTween.cancel(container1.gameObject);
                                container1.anchoredPosition = new Vector3(-380, -85, 0);
                                LeanTween.move(container1.GetComponent<RectTransform>(), container1.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                            }
                            break;
                        case 2:
                            if (!sold2) {
                                if (turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH >= container2.GetComponent<ShopSelection>().price) {
                                    turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH = Mathf.Round((turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH - (container2.GetComponent<ShopSelection>().price)) * 100) / 100;

                                    NFTManager.NFTList[container2.GetComponent<ShopSelection>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];

                                    container2.GetChild(4).gameObject.SetActive(false);
                                    container2.GetChild(5).gameObject.SetActive(true);

                                    container2.GetChild(1).GetComponent<Image>().color = new Color(1, 0.76f, 0.76f);

                                    sold2 = true;
                                } else {
                                    LeanTween.cancel(container2.gameObject);
                                    container2.anchoredPosition = container2Pos;
                                    LeanTween.move(container2.GetComponent<RectTransform>(), container2.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                                }
                            } else {
                                LeanTween.cancel(container2.gameObject);
                                container2.anchoredPosition = container2Pos;
                                LeanTween.move(container2.GetComponent<RectTransform>(), container2.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();

                            }
                            break;
                        case 3:
                            if (!sold3) {
                                if (turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH >= container3.GetComponent<ShopSelection>().price) {
                                    turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH = Mathf.Round((turnManager.PlayerChildren[turnManager.turn - 1].GetComponent<PlayerETHManager>().ETH - (container3.GetComponent<ShopSelection>().price))*100)/100;

                                    NFTManager.NFTList[container3.GetComponent<ShopSelection>().thisNFTIndex].owner = turnManager.PlayerChildren[turnManager.turn - 1];

                                    container3.GetChild(4).gameObject.SetActive(false);
                                    container3.GetChild(5).gameObject.SetActive(true);

                                    container3.GetChild(1).GetComponent<Image>().color = new Color(1, 0.76f, 0.76f);

                                    sold3 = true;
                                } else {
                                    LeanTween.cancel(container3.gameObject);
                                    container3.anchoredPosition = container3Pos;
                                    LeanTween.move(container3.GetComponent<RectTransform>(), container3.GetComponent<RectTransform>().anchoredPosition + (Vector2.right * 5), 0.05f).setLoopPingPong(3).setEaseInOutCirc();
                                }
                            } else {
                                LeanTween.cancel(container3.gameObject);
                                container3.anchoredPosition = container3Pos;
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
                if (Input.GetKeyDown(KeyCode.B)) {
                    BWAnims.AnimIn();
                    BWCS.ActivateChoiceSelection();
                }
                currentChoice = Mathf.Clamp(currentChoice, 1, 3);
            }
        }
        if (shopManager.shopOpen) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                canSelect = false;
                lastChoice = 0;
                currentChoice = 0;
                shopManager.shopOpen = false;
                shopManager.darkWebOn = false;

                LeanTween.cancel(container1);
                LeanTween.cancel(container2);
                LeanTween.cancel(container3);

                BWAnims.SetInvis();

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
        }
    }

    public void ActivateChoiceSelection() {
        LeanTween.cancel(container1);
        LeanTween.cancel(container2);
        LeanTween.cancel(container3);
        shopManager.shopOpen = true;
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

    public void SetEnterInvis() {
        container1.GetChild(4).gameObject.SetActive(false);
        container2.GetChild(4).gameObject.SetActive(false);
        container3.GetChild(4).gameObject.SetActive(false);

        container1.GetChild(5).gameObject.SetActive(false);
        container2.GetChild(5).gameObject.SetActive(false);
        container3.GetChild(5).gameObject.SetActive(false);
    }
}
