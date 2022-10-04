using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerETHManager : MonoBehaviour
{
    public float ETH = 0.00f;

    //References the Player Icons GameObject
    [SerializeField] private GameObject playerIcon;
    [SerializeField] private ETHManager ethManager;
    private TextMeshProUGUI playerIconText;
    private TextMeshProUGUI ETHText;
    public GameObject glow;

    //Reference player
    [SerializeField] private PlayerController player;
    void Start() {
        playerIcon = GameObject.Find($"Player {player.playerInt} Icon");
        playerIconText = playerIcon.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        playerIconText.text = $"Player {player.playerInt}";

        ETHText = playerIcon.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        ETHText.text = $"0.00 ETH";

        glow = playerIcon.transform.GetChild(0).gameObject;
    }

    //If the player comes in contact with an ETH object, destroy the other object and add a random value to the player's wallet
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("ETH")) {
            Destroy(collision.gameObject);
            ETH += Mathf.Round((Random.Range(0.1f, 0.3f))*100)/100;
            ETHText.text = $"{ETH} ETH";
            ethManager.numOfETH--;
        }
    }
}
