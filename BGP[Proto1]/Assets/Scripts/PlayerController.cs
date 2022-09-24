using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject triangles;
    private string lastPress;
    void Start() { 
    }

    void Update(){
        // Arrow/WASD Control and Triangle Control
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (lastPress != "down") {
                transform.Translate(0, 1, 0);
                triangles.transform.rotation = Quaternion.Euler(0, 0, 0);
                lastPress = "up";
            } else print("Cannot move up");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (lastPress != "right") {
                transform.Translate(-1, 0, 0);
                triangles.transform.rotation = Quaternion.Euler(0, 0, 90);
                lastPress = "left";
            } else print("Cannot move left");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            if (lastPress != "up") {
                transform.Translate(0, -1, 0);
                triangles.transform.rotation = Quaternion.Euler(0, 0, 180);
                lastPress = "down";
            } else print("Cannot move down");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (lastPress != "left") {
                transform.Translate(1, 0, 0);
                triangles.transform.rotation = Quaternion.Euler(0, 0, -90);
                lastPress = "right";
            } else print("Cannot move right");
        }
    }
}
