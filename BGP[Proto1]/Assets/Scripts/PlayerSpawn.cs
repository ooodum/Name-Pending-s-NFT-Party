using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    //Variable that denotes the amount of players that want to play
    public int numberOfPlayers = 2;

    //References the board and the players
    public GameObject gameBoard;
    public GameObject players;

    //Create two lists: One for the spawn locations and one for the players
    List<GameObject> SpawnChildren = new List<GameObject>();
    List<GameObject> PlayerChildren = new List<GameObject>();

    void Awake() {
        numberOfPlayers = PlayerPrefs.GetInt("numKey");
    }
    void Start() {
        //Puts the spawns in the spawn list
        foreach(Transform child in gameBoard.transform) {
            if (child.name == "Spawn") {
                SpawnChildren.Add(child.gameObject);
            }
        }

        //Put the players in the player list
        foreach(Transform child in players.transform) {
            if (child.CompareTag("Player")) {
                PlayerChildren.Add(child.gameObject);
            }
        }
        //Loop through depending on however many players there are
        for (int i = 0; i < numberOfPlayers; i++) {
            //Create a temporary random number
            int tempRandom = Random.Range(0, SpawnChildren.Count);
            //Spawn the player at one of the random spawn locations
            PlayerChildren[i].transform.position = SpawnChildren[tempRandom].transform.position;
            //Make the player visible
            PlayerChildren[i].SetActive(true);
            //Remove that spawn location so that two players cannot spawn at the same place
            SpawnChildren.RemoveAt(tempRandom);
        }
    }
    public GameObject getPlayerPositions(int playerID, Transform player) {
        foreach (GameObject child in PlayerChildren) {
            if ((player.position - child.transform.position).magnitude < 0.1f ) {
                if (player.GetComponent<PlayerController>().playerInt != child.GetComponent<PlayerController>().playerInt) {
                    return child;
                }
            }
        }
        return null;
    }
}
