using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookshelfPuzzleRewardBook : MonoBehaviour
{
    private Rigidbody rb;
    private ParticleSystem ps;
    private XRGrabInteractable xrG;
    public float force = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        xrG = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropBook()
    {
        ps.Play();
        rb.AddForce(Vector3.back * force, ForceMode.Impulse);
        xrG.enabled = true;
    }
}
