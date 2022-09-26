using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject upTri;
    public GameObject leftTri;
    public GameObject rightTri;
    public GameObject downTri;


    private string lastPress;

    private int turnPhase = 1;
    private int diceRoll;
    void Start() {
        print("Press space to roll die");
    }

    void Update(){
        if (turnPhase == 1) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                diceRoll = Random.Range(1, 299);
                Debug.Log(diceRoll);
                turnPhase++;
            }
        }
        if (turnPhase == 2) {
            if (diceRoll > 0) {
                movePlayer();
            } else if(diceRoll == 0) {
                print("no more turns, exiting");
                turnPhase++;
            }
        }
    }

    void movePlayer() {
        // Arrow/WASD Control
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && upTri.GetComponent<SpriteRenderer>().enabled) {
            //If the pressed key is not opposite of last direction
            if (lastPress != "down") {
                //Set all but the opposite-side-triangle active
                upTri.SetActive(true);
                leftTri.SetActive(true);
                rightTri.SetActive(true);
                downTri.SetActive(false);
                //If the player is allowed to move in the direction, move one unit
                if (upTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(0, 1, 0);
                    //Dice decrement
                    diceRoll--;
                    print(diceRoll);
                }
                //Set the lastPress variable to the current direction
                lastPress = "up";
            } else print("Cannot move up"); //Debug
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && leftTri.GetComponent<SpriteRenderer>().enabled) {
            if (lastPress != "right") {
                upTri.SetActive(true);
                leftTri.SetActive(true);
                rightTri.SetActive(false);
                downTri.SetActive(true);

                if (leftTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(-1, 0, 0);
                    diceRoll--;
                    print(diceRoll);
                }
                lastPress = "left";
            } else print("Cannot move left");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && downTri.GetComponent<SpriteRenderer>().enabled) {
            if (lastPress != "up") {
                upTri.SetActive(false);
                leftTri.SetActive(true);
                rightTri.SetActive(true);
                downTri.SetActive(true);

                if (downTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(0, -1, 0);
                    diceRoll--;
                    print(diceRoll);
                }
                lastPress = "down";
            } else print("Cannot move down");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && rightTri.GetComponent<SpriteRenderer>().enabled) {
            if (lastPress != "left") {
                upTri.SetActive(true);
                leftTri.SetActive(false);
                rightTri.SetActive(true);
                downTri.SetActive(true);

                if (rightTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(1, 0, 0);
                    diceRoll--;
                    print(diceRoll);
                }
                lastPress = "right";
            } else print("Cannot move right");
        }
    }
}
