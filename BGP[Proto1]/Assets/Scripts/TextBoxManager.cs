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

    //References the player
    public GameObject player;

    //Gets the last animation
    private string lastAnim = null;
    public bool animDone = false;
    void Start() {
        //Sets the text box position at a higher position
        transform.position = up.transform.position;
        LeanTween.alpha(gameObject, 0, 0f);
        AnimTextTransparency(text, 1, 0, 0, 0);
    }

    void Update(){
        //Once the dice is rolled, animate the textbox in
        if (transform.parent.GetComponent<PlayerController>().turnPhase == 2) {
            AnimIn();
            lastAnim = "AnimIn";
        //Once the turn is over, animate the textbox out
        } else if (transform.parent.GetComponent <PlayerController>().turnPhase == 3) {
            AnimOut();
            lastAnim = "AnimOut";
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
        if (lastAnim != "AnimIn") {
            animDone = false;
            //Move the textbox to the bottom position
            LeanTween.moveY(gameObject, down.transform.position.y, 0.75f).setEaseOutCirc();
            LeanTween.alpha(gameObject, 1, 0.2f).setEaseOutExpo();
            AnimTextTransparency(text, 0, 1, 0.1f, 0);
        }
        //Stops animation after it gets close enough
        if ((transform.position.y - down.transform.position.y) < 0.05f) {
            LeanTween.cancel(gameObject);
            LeanTween.cancel(text.gameObject);
            animDone = true;
        }
        if (animDone) {
            transform.position = Vector3.Lerp(transform.position, down.transform.position, Time.deltaTime*25);
        }
        //Turns on the textbox
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //Enable the text and set it to say the number of inputs the player has left (the dice value)
        text.enabled = true;
        text.text = ($"{player.GetComponent<PlayerController>().diceRoll}");
    }

    //Animates the player out (pretty much the same code as AnimIn)
    void AnimOut() {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (lastAnim != "AnimOut") {
            LeanTween.moveY(gameObject, up.transform.position.y, 1f).setEaseOutQuad();
            LeanTween.alpha(gameObject, 0, 0.2f).setEaseInExpo();
            AnimTextTransparency(text, 1, 0, 0.1f, 0);
        }
    }

    void AnimTextTransparency(TextMeshProUGUI text, float start, float end, float value, float delay) {
        LeanTween.value(text.gameObject, start, end, value).setDelay(delay).setOnUpdate((value) => {
            Color c = text.faceColor;
            c.a = value;
            text.faceColor = c;
        });
    }
}
