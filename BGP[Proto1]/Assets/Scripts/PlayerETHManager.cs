using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerETHManager : MonoBehaviour
{
    public float ETH = 0;
    void Start() {
        
    }

    void Update() {
        
    }

    //If the player comes in contact with an ETH object, destroy the other object and add a random value to the player's wallet
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("ETH")) {
            Destroy(collision.gameObject);
            ETH += Mathf.Round((Random.Range(0.1f, 0.3f))*100)/100;
            print(ETH);
        }
    }
}
