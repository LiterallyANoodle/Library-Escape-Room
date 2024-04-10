using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ConduitPowerableEndpoint : PseudoPowerable
{

    private List<ConduitPowerableEndpoint> TXs;
    public List<PseudoPowerable> permanentConnections;
    public UnityEvent justPowered;

    void Awake() {
        this.TXs = new List<ConduitPowerableEndpoint>();
    }

    void Update() {
        this.RX();
    }

    public void OnTriggerEnter(Collider other) {
        print("Enter " + other.GetComponentInChildren<ConduitPowerableEndpoint>().ToString());
        if (other.GetComponent<ConduitPowerableEndpoint>() != null) {
            this.TXs.Add(other.GetComponent<ConduitPowerableEndpoint>());
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.GetComponent<ConduitPowerableEndpoint>() != null) {
            this.TXs.Remove(other.GetComponent<ConduitPowerableEndpoint>());
        }
    }

    public void RX() {
        PoweredState result = PoweredState.UNPOWERED;
        foreach (ConduitPowerableEndpoint TX in this.TXs)
        {
            if (TX.isPowered()) {
                result = PoweredState.POWERED;
            }
        }
        if (this.permanentConnections != null) {
                foreach (PseudoPowerable endpoint in this.permanentConnections) {
                if (endpoint.isPowered()) {
                    result = PoweredState.POWERED;
                }
            }
        }
        // check if newly powered from unpowered state
        if (this.powered == PoweredState.UNPOWERED && result == PoweredState.POWERED) {
            print("JustPowered " + this.name.ToString());
            justPowered.Invoke();
        }
        this.powered = result;
    }
    
}
