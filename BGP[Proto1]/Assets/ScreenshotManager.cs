using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenshotManager : MonoBehaviour {
    [SerializeField] private NFTManager NFTManager;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private Image overlay;
    private string lastAnim;
    void Start() {
    }

    void Update() {
        
    }
    public void ScreenshotPlayer() {
        if (lastAnim != "SS") {
            lastAnim = "SS";
            overlay.gameObject.SetActive(true);
            shopManager.AnimImageTransparency(overlay, 1, 0, 1f, 0);
        }
    }
    bool CheckAvailability(GameObject other) {
        foreach(NFTInfo child in NFTManager.NFTList) {
            if (child.owner == other) {
                return true;
            } else return false;
        } return false;
    }
}
