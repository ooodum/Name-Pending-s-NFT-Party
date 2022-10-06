using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopETHTextManager : MonoBehaviour {
    [SerializeField] private GameObject players;
    [SerializeField] List<PlayerETHManager> playerList = new List<PlayerETHManager>();
    [SerializeField] private TextMeshProUGUI ETHText;
    [SerializeField] private TextMeshProUGUI darkWebETHText;
    [SerializeField] private TurnManager turnManager;
    void Start() {
        foreach (Transform child in players.transform) {
            if (child.CompareTag("Player")) {
                playerList.Add(child.GetComponent<PlayerETHManager>());
            }
        }
    }

    void Update() {
        ETHText.text = $"{(Mathf.Round(playerList[turnManager.turn - 1].ETH*100))/100} ETH";
        darkWebETHText.text = $"{(Mathf.Round(playerList[turnManager.turn - 1].ETH*100))/100} ETH";
    }
}
