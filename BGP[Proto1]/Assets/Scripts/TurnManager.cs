using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    //Defines whose turn it is
    public int turn;

    //Creates a list that stores the players added to the game
    List<GameObject> PlayerChildren = new List<GameObject>();

    //References the player and the camera
    public GameObject players;
    public GameObject cam;

    //SmoothDamp prereq's
    private Vector3 vel = Vector3.zero;
    public float moveTime = 0.5f;

    //Set the camera offset
    private Vector3 camOffset = new Vector3(0, 0, -10f);

    //Reference the player spawner
    public PlayerSpawn playerSpawn;

    void Start() {
        //Set the current turn to the amount of players there are (because the game will increment the turn, so it will return to 1 once the game starts)
        turn = playerSpawn.numberOfPlayers;
        
        //For every player inside the players GameObject, add that player to a list
        foreach (Transform child in players.transform) {
            if (child.CompareTag("Player")) {
                PlayerChildren.Add(child.gameObject);
            }
        }

        //Call the ChangeTurn function
        ChangeTurn();
    }

    //Set the camera to smoothly move to the player whose turn it is 
    void FixedUpdate() {
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, PlayerChildren[turn - 1].transform.position + camOffset, ref vel, moveTime);
    }

    //The process to change turns from one player to another
    public void ChangeTurn() {
        //Get the current player's triangles and disable them
        PlayerChildren[turn - 1].transform.Find("Triangles").gameObject.SetActive(false);
        //Increment the turn, but if it's the last player's turn, set the turn back to 1
        if (turn < playerSpawn.numberOfPlayers) turn++; else turn = 1;
        //Set the next player's turnPhase to 1 (Press space to roll dice)
        PlayerChildren[turn - 1].GetComponent<PlayerController>().turnPhase = 1;
        //Enable their triangles
        PlayerChildren[turn-1].transform.Find("Triangles").gameObject.SetActive(true);
    }
}
