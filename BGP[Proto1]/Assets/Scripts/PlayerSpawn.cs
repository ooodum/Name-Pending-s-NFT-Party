using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject gameBoard;
    public GameObject players;
    List<GameObject> SpawnChildren = new List<GameObject>();
    List<GameObject> PlayerChildren = new List<GameObject>();
    void Start() {
        foreach(Transform child in gameBoard.transform) {
            if (child.name == "Spawn") {
                SpawnChildren.Add(child.gameObject);
            }
        }
        foreach(Transform child in players.transform) {
            if (child.CompareTag("Player")) {
                PlayerChildren.Add(child.gameObject);
            }
        }
        for (int i = 0; i < 4; i++) {
            int tempRandom = Random.Range(0, SpawnChildren.Count);
            PlayerChildren[i].transform.position = SpawnChildren[tempRandom].transform.position;
            SpawnChildren.RemoveAt(tempRandom);
        }
    }

    void Update() {
        
    }
}
