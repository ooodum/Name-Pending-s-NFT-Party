using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETHAnimation : MonoBehaviour {
    void Start() {
        LeanTween.moveLocalY(gameObject, transform.position.y + 0.1f, Random.Range(0.5f,1f)).setEaseOutSine().setLoopPingPong();
    }
}
