using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour {
    //SmoothDamp prereqs
    private Vector3 vel = Vector3.zero;
    private float moveTime = 20f;

    //References two invisible game objects, one placed higher than the player's position, and another placed just above
    public GameObject up;
    public GameObject down;

    //References the text
    public TextMeshProUGUI text;

    //Referencest the player
    public GameObject player;

    void Start() {
        //Sets the text box position at a higher position
        transform.position = up.transform.position;
    }

    void Update(){
        //Once the dice is rolled, animate the textbox in
        if (transform.parent.GetComponent<PlayerController>().turnPhase == 2) {
            StartCoroutine(AnimIn());
        //Once the turn is over, animate the textbox out
        } else if (transform.parent.GetComponent <PlayerController>().turnPhase == 3) {
            StartCoroutine(AnimOut());
        //Make sure that the textbox is always invisible when it's not the player's turn
        } else {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            text.enabled = false;
            transform.position = up.transform.position;
            StopAllCoroutines();
        }
        
    }
    //Animates the player in
    IEnumerator AnimIn() {
        //Turns on the textbox
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //As long as the textbox hasn't gotten to the bottom position (which it will never because of smoothdamp. kills two birds with one stone):
        while (transform.position != down.transform.position) {
            //Enable the text and set it to say the number of inputs the player has left (the dice value)
            text.enabled = true;
            text.text = ($"{player.GetComponent<PlayerController>().diceRoll}");

            //Move the textbox to the bottom position
            transform.position = Vector3.SmoothDamp(transform.position, down.transform.position, ref vel, moveTime);
            yield return null;
       }
    }

    //Animates the player out (pretty much the same code as AnimIn)
    IEnumerator AnimOut() {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        while (transform.position != up.transform.position) {
            transform.position = Vector3.SmoothDamp(transform.position, up.transform.position, ref vel, moveTime);
            yield return null;
        }
    }
}
