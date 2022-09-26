using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentCheck : MonoBehaviour
{
    private bool touching;

    private void OnTriggerStay2D(Collider2D collision) {
        touching = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        touching = false;
    }

    void Update() {
        if (touching) {
            GetComponent<SpriteRenderer>().enabled = true;
        } else GetComponent<SpriteRenderer>().enabled = false;
    }
}
