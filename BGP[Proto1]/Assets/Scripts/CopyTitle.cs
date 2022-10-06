using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CopyTitle : MonoBehaviour {
    [SerializeField] TextMeshProUGUI title; 
    void Update() {
        gameObject.GetComponent<TextMeshProUGUI>().faceColor = title.faceColor;
    }
}
