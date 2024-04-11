using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaquePiece : MonoBehaviour
{
    public UnityEvent plaquePlaced;
    public GameObject anchor;
    public bool justReleased;


    public void SelectEntered(SelectEnterEventArgs e) => this.justReleased = false;
    public void SelectExited(SelectEnterEventArgs e) => this.justReleased = true;

    // Start is called before the first frame update
    void Start()
    {
        this.justReleased = false ;
    }

    private void SnapToPlace()
    {
        // transform.SetPositionAndRotation(anchor.transform.position, anchor.transform.rotation);

        // XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        // interactable.enabled = false;

        // Rigidbody body = GetComponent<Rigidbody>();
        // body.useGravity = false;
        // body.isKinematic = true;

        plaquePlaced.Invoke();
    }

    public void checkRangeToSnap()
    {
        // Can't figure out why check doesnt work correctly? I just put a bang to skip it for now
        if (!justReleased)
        {
            float distanceToAnchor = Vector3.Distance(this.transform.position, anchor.transform.position);
            if (distanceToAnchor < 0.1f)
            {
                SnapToPlace();
            }
        }
    }
}
