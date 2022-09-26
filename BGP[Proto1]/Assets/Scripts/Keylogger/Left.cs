using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            transform.localScale = new Vector3(0.25f, 0.25f);
        } else transform.localScale = new Vector3(0.5f, 0.5f);
    }
}
