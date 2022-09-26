using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            transform.localScale = new Vector3(0.25f, 0.25f);
        } else transform.localScale = new Vector3(0.5f, 0.5f);
    }
}
