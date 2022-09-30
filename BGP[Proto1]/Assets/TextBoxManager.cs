using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour {
    private Vector3 vel = Vector3.zero;
    private float moveTime = 20f;
    public GameObject up;
    public GameObject down;
    public TextMeshProUGUI text;
    public GameObject player;

    void Start() {
        transform.position = up.transform.position;
    }

    void Update(){
        if (transform.parent.GetComponent<PlayerController>().turnPhase == 2) {
            StartCoroutine(AnimIn());
        } else if (transform.parent.GetComponent <PlayerController>().turnPhase == 3) {
            StartCoroutine(AnimOut());
        } else {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            text.enabled = false;
            transform.position = up.transform.position;
            StopAllCoroutines();
        }
        
    }
    IEnumerator AnimIn() {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        while (transform.position != down.transform.position) {
            text.enabled = true;
            text.text = ($"{player.GetComponent<PlayerController>().diceRoll}");
            transform.position = Vector3.SmoothDamp(transform.position, down.transform.position, ref vel, moveTime);
            yield return null;
       }
    }

    IEnumerator AnimOut() {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        while (transform.position != up.transform.position) {
            transform.position = Vector3.SmoothDamp(transform.position, up.transform.position, ref vel, moveTime);
            yield return null;
        }
    }
}
