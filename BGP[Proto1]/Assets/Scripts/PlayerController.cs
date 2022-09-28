using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Reference each of the four triangles surrounding the player
    public GameObject upTri;
    public GameObject leftTri;
    public GameObject rightTri;
    public GameObject downTri;

    //The last pressed key (that was a "valid" move)
    private string lastPress;

    //Defines which phase of the turn the player is on (Rolling dice, moving, etc.)
    private int turnPhase = 1;

    //Says whether or not the player is allowed to move
    private bool canMove = true;

    //The value of the dice roll
    private int diceRoll;

    //The position where the player will smoothly move to (SD stands for SmoothDamp)
    private Vector3 SDPos;

    //Simple debounce for SmoothDamp function for player movement (for performance purposes)
    private bool SDCheck = false;

    //Move speed of SmoothDamp. Lower is faster.
    private float moveSpeed = 10f;

    //Used for SmoothDamp
    private Vector2 vel = Vector2.zero;

    //A value that is compared against the magnitude of the position of the player and SDPos (for performance purposes)
    private double epsilon = 1.68584e-2;
    void Start() {
        SDPos = transform.position;
        print("Press space to roll die");
    }

    void Update(){
        switch (turnPhase) {
            case 1:
                if (Input.GetKeyDown(KeyCode.Space)) {
                    diceRoll = Random.Range(1, 7);
                    Debug.Log(diceRoll);
                    turnPhase++;
                }
                break;
            case 2:
                if (diceRoll > 0 && canMove) {
                    movePlayer();
                } else if (diceRoll == 0) {
                    turnPhase--;
                }
                break;
            default:
                break;
        }
    }

    void movePlayer() {
        // Arrow/WASD Control
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && upTri.GetComponent<SpriteRenderer>().enabled) {
            //If the pressed key is not opposite of last direction
            if (lastPress != "down") {
                //Set all but the opposite-side-triangle active
                upTri.SetActive(true);
                leftTri.SetActive(true);
                rightTri.SetActive(true);
                downTri.SetActive(false);

                SDPos = upTri.GetComponent<AdjacentCheck>().tile.transform.position;
                SDCheck = (transform.position.y < upTri.GetComponent<AdjacentCheck>().tile.transform.position.y);
                //Dice decrement
                diceRoll--;
                print(diceRoll);

                //Set the lastPress variable to the current direction
                lastPress = "up";
            }
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && leftTri.GetComponent<SpriteRenderer>().enabled) {
            if (lastPress != "right") {
                upTri.SetActive(true);
                leftTri.SetActive(true);
                rightTri.SetActive(false);
                downTri.SetActive(true);

                SDPos = leftTri.GetComponent<AdjacentCheck>().tile.transform.position;
                SDCheck = (transform.position.x > leftTri.GetComponent<AdjacentCheck>().tile.transform.position.x);
                diceRoll--;
                print(diceRoll);

                lastPress = "left";
            } 
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && downTri.GetComponent<SpriteRenderer>().enabled) {
            if (lastPress != "up") {
                upTri.SetActive(false);
                leftTri.SetActive(true);
                rightTri.SetActive(true);
                downTri.SetActive(true);

                SDPos = downTri.GetComponent<AdjacentCheck>().tile.transform.position;
                SDCheck = (transform.position.y > downTri.GetComponent<AdjacentCheck>().tile.transform.position.y);
                diceRoll--;
                print(diceRoll);

                lastPress = "down";
            }
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && rightTri.GetComponent<SpriteRenderer>().enabled) {
            if (lastPress != "left") {
                upTri.SetActive(true);
                leftTri.SetActive(false);
                rightTri.SetActive(true);
                downTri.SetActive(true);

                SDPos = rightTri.GetComponent<AdjacentCheck>().tile.transform.position;
                SDCheck = (transform.position.x < rightTri.GetComponent<AdjacentCheck>().tile.transform.position.x);
                diceRoll--;
                print(diceRoll);
                
                lastPress = "right";
            } 
        }
    }

    void FixedUpdate() {
        if (SDCheck) {
            canMove = false;
            transform.position = Vector2.SmoothDamp(transform.position, SDPos, ref vel, moveSpeed * Time.deltaTime);
            if ((transform.position - SDPos).magnitude < epsilon) {
                canMove = true;
                SDCheck = false;
                transform.position = SDPos;
            }
        }
    }
}
