using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {
    //Reference each of the four triangles surrounding the player
    public GameObject upTri;
    public GameObject leftTri;
    public GameObject rightTri;
    public GameObject downTri;
    public GameObject fourTri;

    //Reference each player
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    [SerializeField] private GameObject p3;
    [SerializeField] private GameObject p4;

    //References the PlayerETHManager script
    public PlayerETHManager ETHManager;

    //Reference the textbox
    [SerializeField] private GameObject textbox;

    //Defines which player it is
    public int playerInt;

    //References the Game Manager's Turn Manager
    public TurnManager turnManager;

    //References the Shop Manager's Shop Manager
    public ShopManager shopManager;

    //Defines which phase of the turn the player is on (Rolling dice, moving, etc.)
    public int turnPhase = -1;

    //Reference a tile on the screen
    [SerializeField] private Vector2 tileSize = new Vector2(0.6f, 0.6f);
    private float boardSize = 2f;

    //The last pressed key (that was a "valid" move)
    private string lastPress;

    //The value of the dice roll
    public int diceRoll;

    //Says whether or not the player is allowed to move
    private bool canMove = true;

    //The position where the player will smoothly move to (SD stands for SmoothDamp)
    private Vector3 SDPos;

    //Simple debounce for SmoothDamp function for player movement (for performance purposes)
    private bool SDCheck = false;

    //Gets the current tile
    [SerializeField] private Collider2D currentTile;

    //Move speed of SmoothDamp. Lower is faster.
    private float moveSpeed = 0.1f;

    //Used for SmoothDamp
    private Vector2 vel = Vector2.zero;

    //A value that is compared against the magnitude of the position of the player and SDPos (for performance purposes)
    private double epsilon = 1.68584e-2;

    //A simple debounce to ensure the IEnumerator works properly since it's in the update function.
    private bool turnChangeDebounce = true;

    //Reference Side Text (A little popup on the side that appears whenever the player needs to do an action)
    public TextMeshProUGUI sideText;

    //Says whether or not the side text needs to be visible
    public bool sideTextNeeded = false;

    //Get the player you're about to collide with
    [SerializeField] private GameObject otherPlayer;

    //References the Screenshot Manager
    [SerializeField] ScreenshotManager screenshotManager;
    [SerializeField] PlayerSpawn playerSpawn;

    //Set last animation
    private string lastAnim;
    

    void Awake() {

        //Sets position to the player
        SDPos = transform.position;

        //Set the size of the player according to the size of the tile.
        transform.localScale = (tileSize / 1.5f )* boardSize;
    }

    void Update(){
        //A switch for which phase of a player's turn it is.
        switch (turnPhase) {
            //Phase 1: Press space to roll
            case 1:
                //Enable player icon glow
                ETHManager.glow.SetActive(true);
                //Enable the sidebar and tell the player to press space to roll dice
                sideText.text = ("SPACE to roll");
                sideTextNeeded = true;

                //If the player presses the spacebar and it's the player's turn:
                if (Input.GetKeyDown(KeyCode.Space) && playerInt == turnManager.turn) {
                    //Roll the dice and move on to Phase 2
                    diceRoll = Random.Range(1, 7);
                    turnPhase = 2;
                }
                break;
            //Phase 2: Player is allowed to move and do actions
            case 2:
                //Turn off the sidebar
                sideTextNeeded = false;

                //If the dice hasn't reached zero yet, the player is allowed to move, and it's the player's turn:
                if (diceRoll > 0 && canMove && textbox.GetComponent<TextBoxManager>().animDone && playerInt == turnManager.turn) {
                    //If the player comes by a shop:
                    if (currentTile.name == "Shop") {
                        //Enable the sidebar to tell the player to press space to open the shop if they want to.
                        sideText.text = ("SPACE to buy");
                        sideTextNeeded = true;
                        //If the spacebar is pressed while standing on a shop, move on to Phase 10
                        if (Input.GetKeyDown(KeyCode.Space)) {
                            turnPhase = 10;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.O)) diceRoll--;
                    if (Input.GetKeyDown(KeyCode.P)) diceRoll++;
                    //Calls the movePlayer function
                    movePlayer();

                //When the dice finally reaches zero, and animations have finished
                } else if (diceRoll == 0 && !SDCheck) {
                    //Turn off the four triangles
                    fourTri.SetActive(false);
                    //If the player happens to come to a shop on their last step of the dice:
                    if (currentTile.name == "Shop") {
                        //Enable the sidebar and tell the player to open the shop or skip turn
                        sideText.text = ("SPACE to buy or ENTER to end turn");
                        sideTextNeeded = true;
                        //If the player presses space, move on to Phase 10
                        if (Input.GetKeyDown(KeyCode.Space)) {
                            turnPhase = 10;
                        }
                        //If the player wants to skip their turn, the enter key will move them on to Phase 3
                        if (Input.GetKeyDown(KeyCode.Return)) turnPhase = 3;
                    } else turnPhase = 3;
                }
                break;
            case 3:
                //Wait 0.25 seconds, then move on to Phase 4
                if (turnChangeDebounce) {
                    turnChangeDebounce = false;
                    StartCoroutine(WaitUntilTurnChange(0.45f));
                }
                break;
            case 4:
                lastAnim = null;
                //Ask the Turn Manager to move on to the next player's turn
                turnManager.ChangeTurn();
                //Turn off player glow
                ETHManager.glow.SetActive(false);
                //Makes sure that no turn phases are active
                turnPhase = -1;
                break;
            case 10:
                //Disable the four triangles
                fourTri.SetActive(false);
                //Open the shop UI
                shopManager.ShopAnimIn();
                shopManager.lastAnim = "ShopAnimIn";
                //Let the player know they can close the shop by pressing the spacebar
                sideText.text = ("SPACE to close shop");
                sideTextNeeded = true;
                //Close the shop if the player presses space
                if (Input.GetKeyDown(KeyCode.Space)) {
                    //Close the shop
                    shopManager.ShopAnimOut();
                    shopManager.lastAnim = "ShopAnimOut";
                    //Go back to phase 2
                    turnPhase = 2;
                    //If the player can still move after closing the shop, enable the four triangles again
                    if (diceRoll > 0) fourTri.SetActive(true);
                } 
                break;
            case 11:
                StopAllCoroutines();
                screenshotManager.ScreenshotPlayer(otherPlayer, gameObject);
                break;
            case 12:
                if (lastAnim != "12") {
                    lastAnim = "12";
                    LeanTween.move(turnManager.gameObject, turnManager.gameObject.transform.position, 0.45f).setOnComplete(SendBackToFour);
                }
                break;
            default:
                break;
        }
    }

    //Function for player movement
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

                //Sets the position to the tile the player is about to go to
                SDPos = upTri.GetComponent<AdjacentCheck>().tile.transform.position;
                //Checks if the player hasn't reached its destination
                SDCheck = (transform.position.y < upTri.GetComponent<AdjacentCheck>().tile.transform.position.y);

                //Dice decrement
                diceRoll--;

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

                lastPress = "right";
            }
        }
    }

    //Use FixedUpdate to prevent jittering due to animation
    void FixedUpdate() {
        //If the player hasn't reached it's destination:
        if (SDCheck) {
            //Don't allow the player to input while the player is moving to the tile
            canMove = false;
            //Smoothly move the player to the next tile
            transform.position = Vector2.SmoothDamp(transform.position, SDPos, ref vel, moveSpeed);
            //While the player is moving, disable the four triangles
            fourTri.SetActive(false);
            //If the player's position is close enough to the tile:
            if ((transform.position - SDPos).magnitude < epsilon) {
                //Turn off the smoothdamp (to save resources)
                SDCheck = false;
                //Allow the player to input again
                canMove = true;
                //Snap the player's position to the tile
                transform.position = SDPos;
                //If the player is still in their moving/input phase, turn on the triangles again
                if (turnPhase == 2) {
                    fourTri.SetActive(true);
                }
            }
        }
    }

    //Sets the currentTile to whatever tile the player is standing on
    private void OnTriggerStay2D(Collider2D collision) {
        currentTile = collision;
    }

    //Wait an amount of time before ending the player's turn
    IEnumerator WaitUntilTurnChange(float sec) {
        yield return new WaitForSeconds(sec);
        otherPlayer = playerSpawn.getPlayerPositions(playerInt, gameObject.transform);
        if (otherPlayer != null) {
            turnPhase = 11;
        } else turnPhase = 4;
        turnChangeDebounce = true;           
    }
    void SendBackToFour() {
        turnPhase = 4;
    }
}
