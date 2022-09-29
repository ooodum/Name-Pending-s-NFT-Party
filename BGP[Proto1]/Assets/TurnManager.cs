using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    //Defines whose turn it is
    public int turn = 4;
    List<GameObject> PlayerChildren = new List<GameObject>();
    public GameObject players;

    void Start() {
        foreach (Transform child in players.transform) {
            if (child.CompareTag("Player")) {
                PlayerChildren.Add(child.gameObject);
            }
        }
        ChangeTurn();
    }

    void Update() {

     
    }
    public void ChangeTurn() {
        PlayerChildren[turn - 1].transform.Find("Triangles").gameObject.SetActive(false);
        if (turn < 4) turn++; else turn = 1;
        print($"It is now player {turn}'s turn");
        PlayerChildren[turn-1].transform.Find("Triangles").gameObject.SetActive(true);
    }
}
