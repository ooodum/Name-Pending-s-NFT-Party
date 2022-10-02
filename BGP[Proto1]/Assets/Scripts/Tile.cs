using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Collider2D currentPiece;
    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        currentPiece = collision;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        currentPiece = null;
    }
}
