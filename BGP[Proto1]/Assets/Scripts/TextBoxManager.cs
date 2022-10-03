using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour {
    //References two invisible game objects, one placed higher than the player's position, and another placed just above
    public GameObject up;
    public GameObject down;

    //References the text
    public TextMeshProUGUI text;

    //Referencest the player
    public GameObject player;

    //Debounce so that animations only run once
    private bool debounce = false;
    void Start() {
        //Sets the text box position at a higher position
        transform.position = up.transform.position;
        LeanTween.alpha(gameObject, 0, 0f);
    }

    void Update(){
        //Once the dice is rolled, animate the textbox in
        if (transform.parent.GetComponent<PlayerController>().turnPhase == 2) {
            AnimIn();
        //Once the turn is over, animate the textbox out
        } else if (transform.parent.GetComponent <PlayerController>().turnPhase == 3) {
            AnimOut();
        //Make sure that the textbox is always invisible when it's not the player's turn
        } else {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            text.enabled = false;
            transform.position = up.transform.position;
            StopAllCoroutines();
        }
        
    }
    //Animates the player in
    void AnimIn() {
        debounce = true;
        if (debounce) {
            debounce = false;
            //Turns on the textbox
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

            //Move the textbox to the bottom position
            LeanTween.moveY(gameObject, down.transform.position.y, 0.3f);
            LeanTween.alpha(gameObject, 1, 0.2f).setEaseOutExpo();
            if ((transform.position.y - down.transform.position.y) < 0.05f) {
                LeanTween.cancelAll();
            }

            //Enable the text and set it to say the number of inputs the player has left (the dice value)
            text.enabled = true;
            text.text = ($"{player.GetComponent<PlayerController>().diceRoll}");
        }
    }

    //Animates the player out (pretty much the same code as AnimIn)
    void AnimOut() {
        debounce = true;
        if (debounce) {
            debounce = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            LeanTween.moveY(gameObject, up.transform.position.y, 0.3f);
            LeanTween.alpha(gameObject, 0, 0.2f).setEaseInExpo();
        }
    }
}
