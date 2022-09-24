using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentCheck : MonoBehaviour
{
    void Start() {
        
    }
    void Update() {
        Debug.DrawRay(transform.position, transform.up, Color.green);
    }

    void ShootRaycast() {
        RaycastHit2D raycastHit;
    }
}
