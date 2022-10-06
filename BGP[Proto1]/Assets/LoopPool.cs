using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPool : MonoBehaviour {
    public List<Sprite> loopPool = new List<Sprite>();
    [SerializeField] LoadNFTSprites LNS;
    void Start() {
        loopPool.Add(LNS.Dis0);
        loopPool.Add(LNS.Dis1);
        loopPool.Add(LNS.Dis2);
        loopPool.Add(LNS.Dis3);
        loopPool.Add(LNS.Dis4);
        loopPool.Add(LNS.Dis5);
        loopPool.Add(LNS.Dis6);

        loopPool.Add(LNS.Ex0);
        loopPool.Add(LNS.Ex1);
        loopPool.Add(LNS.Ex2);
        loopPool.Add(LNS.Ex3);
        loopPool.Add(LNS.Ex4);

        loopPool.Add(LNS.MS0);
        loopPool.Add(LNS.MS1);
        loopPool.Add(LNS.MS2);
        loopPool.Add(LNS.MS3);
        loopPool.Add(LNS.MS4);
        loopPool.Add(LNS.MS5);

        loopPool.Add(LNS.Nen0);
        loopPool.Add(LNS.Nen1);
        loopPool.Add(LNS.Nen2);
        loopPool.Add(LNS.Nen3);
        loopPool.Add(LNS.Nen4);
        loopPool.Add(LNS.Nen5);
        loopPool.Add(LNS.Nen6);

        loopPool.Add(LNS.UB0);
        loopPool.Add(LNS.UB1);
        loopPool.Add(LNS.UB2);
        loopPool.Add(LNS.UB3);
        loopPool.Add(LNS.UB4);
    }

    void Update() {
        
    }
}
