using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            transform.localScale = new Vector3(0.25f, 0.25f);
        } else transform.localScale = new Vector3(0.5f, 0.5f);
    }
}
