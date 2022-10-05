using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWebChoiceSelection : MonoBehaviour {
    [SerializeField] private ShopManager shopManager;
    [SerializeField] PlayerChoiceSelection PCS;

    [SerializeField] private BlackWebAnims BWAnims;

    public bool canSelect;
    void Start() {
        
    }

    void Update() {
        if (shopManager.darkWebOn && shopManager.shopOpen) {
            if (canSelect) {
                if (Input.GetKeyDown(KeyCode.B)) {
                    BWAnims.AnimOut();
                }
                if (Input.GetKeyDown(KeyCode.Space)) {
                    BWAnims.AnimOut();
                    PCS.SetEnterInvis();
                    shopManager.shopOpen = false;
                }
            }
        }
    }
}
