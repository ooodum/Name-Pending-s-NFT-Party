using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animInOut : MonoBehaviour {
    [SerializeField] private PlayerController p1Text;
    [SerializeField] private PlayerController p2Text;
    [SerializeField] private PlayerController p3Text;
    [SerializeField] private PlayerController p4Text;

    private Vector3 vel = Vector3.zero;
    private float moveTime = 0.2f;

    private Vector3 outPos = new Vector3(258, 302, 0);
    private Vector3 inPos = new Vector3(-218, 302, 0);

    private void Start() {
    }
    void Update(){
        if (p1Text.sideTextNeeded || p2Text.sideTextNeeded || p3Text.sideTextNeeded || p4Text.sideTextNeeded) {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, outPos, ref vel, moveTime);
        } else GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, inPos, ref vel, moveTime);
    }
}
