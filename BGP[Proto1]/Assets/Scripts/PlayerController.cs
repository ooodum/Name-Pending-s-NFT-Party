using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject upTri;
    public GameObject leftTri;
    public GameObject rightTri;
    public GameObject downTri;
    private string lastPress;
    void Start() { 
    }

    void Update(){
        // Arrow/WASD Control and Triangle Control
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (lastPress != "down") {
                upTri.SetActive(true);
                leftTri.SetActive(true);
                rightTri.SetActive(true);
                downTri.SetActive(false);

                if (upTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(0, 1, 0);
                    lastPress = "up";
                }
            } else print("Cannot move up");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (lastPress != "right") {
                upTri.SetActive(true);
                leftTri.SetActive(true);
                rightTri.SetActive(false);
                downTri.SetActive(true);

                if (leftTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(-1, 0, 0);
                    lastPress = "left";
                }
            } else print("Cannot move left");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            if (lastPress != "up") {
                upTri.SetActive(false);
                leftTri.SetActive(true);
                rightTri.SetActive(true);
                downTri.SetActive(true);

                if (downTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(0, -1, 0);
                    lastPress = "down";
                }
            } else print("Cannot move down");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (lastPress != "left") {
                upTri.SetActive(true);
                leftTri.SetActive(false);
                rightTri.SetActive(true);
                downTri.SetActive(true);

                if (rightTri.GetComponent<SpriteRenderer>().enabled) {
                    transform.Translate(1, 0, 0);
                    lastPress = "right";
                }
            } else print("Cannot move right");
        }
    }
}
