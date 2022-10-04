using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAnimsManager : MonoBehaviour {
    [SerializeField] ShopSelection container1;
    [SerializeField] ShopSelection container2;
    [SerializeField] ShopSelection container3;

    public void AnimIn() {
        container1.AnimIn();
        container2.AnimIn();
        container3.AnimIn();

        container1.lastAnim = "AnimIn";
        container2.lastAnim = "AnimIn";
        container3.lastAnim = "AnimIn";
    }

    public void AnimOut() {
        container1.AnimOut();
        container2.AnimOut();
        container3.AnimOut();

        container1.lastAnim = "AnimOut";
        container2.lastAnim = "AnimOut";
        container3.lastAnim = "AnimOut";
    }
}
