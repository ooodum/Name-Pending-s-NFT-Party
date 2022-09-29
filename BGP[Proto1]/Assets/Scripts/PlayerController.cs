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
    public GameObject fourTri;

    //Defines which player it is
    public int playerInt;

    //References the Game Manager's Turn Manager
    public TurnManager turnManager;

    //Defines which phase of the turn the player is on (Rolling dice, moving, etc.)
    public int turnPhase = 1;

    //Reference a tile on the screen
    public Vector2 tileSize = new Vector2(0.6f, 0.6f);

    //The last pressed key (that was a "valid" move)
    private string lastPress;

    //The value of the dice roll
    private int diceRoll;

    //Says whether or not the player is allowed to move
    private bool canMove = true;

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
        transform.localScale = tileSize / 1.5f;
    }

    void Update(){
        switch (turnPhase) {
            case 1:
                if (Input.GetKeyDown(KeyCode.Space) && playerInt == turnManager.turn) {
                    diceRoll = Random.Range(1, 7);
                    print(diceRoll);
                    turnPhase = 2;
                }
                break;
            case 2:
                if (diceRoll > 0 && canMove && playerInt == turnManager.turn) {
                    movePlayer();
                } else if (diceRoll == 0) {
                    turnPhase = 3;
                    turnManager.ChangeTurn();
                }
                break;
            case 3:
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
            fourTri.SetActive(false);
            if ((transform.position - SDPos).magnitude < epsilon) {
                SDCheck = false;
                if (playerInt == turnManager.turn) {
                    canMove = true;
                    fourTri.SetActive(true);
                    transform.position = SDPos;
                }
            }
        }
    }
}
