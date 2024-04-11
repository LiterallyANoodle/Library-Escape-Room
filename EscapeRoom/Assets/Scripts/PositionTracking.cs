using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracking : MonoBehaviour
{
    
    public GameObject tracking;

    void Awake() {
        this.transform.SetParent(tracking.transform, false);
    }
}
