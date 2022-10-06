using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETHAnimation : MonoBehaviour {
    void Start() {
        Vector3 thisScale = transform.localScale;
        LeanTween.scale(gameObject, Vector3.zero, 0);
        LeanTween.scale(gameObject, thisScale, 1f).setEaseInOutBack().setDelay(1.5f);
        LeanTween.moveLocalY(gameObject, transform.position.y + 0.1f, Random.Range(0.5f,1f)).setEaseOutSine().setLoopPingPong();
    }
}
