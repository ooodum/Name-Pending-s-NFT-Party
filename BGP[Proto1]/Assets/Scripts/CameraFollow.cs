using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //
    public GameObject player;
    private float dampeningTime = 0.1f;
    private Vector3 vel = Vector3.zero;
    void Start() {
        
    }

    void Update() {
        if (player) {
            Vector3 pointPos = Camera.main.WorldToViewportPoint(player.transform.position);
            Vector3 delta = player.transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, pointPos.z));
            Vector3 dest = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, dest, ref vel, dampeningTime);
        }
    }
}
