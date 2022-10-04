using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Collider2D currentPiece;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            currentPiece = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        currentPiece = null;
    }
}
