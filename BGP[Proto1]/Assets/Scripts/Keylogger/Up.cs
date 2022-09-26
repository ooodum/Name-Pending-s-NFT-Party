using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            transform.localScale = new Vector3(0.25f, 0.25f);
        } else transform.localScale = new Vector3(0.5f, 0.5f);
    }
}
