using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            transform.localScale = new Vector3(10f, 10f);
        } else transform.localScale = new Vector3(15f, 15f);
    }
}
