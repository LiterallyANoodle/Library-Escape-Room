using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoweredState {
    UNPOWERED,
    POWERED,
}

public class ConduitPowerableEndpoint : MonoBehaviour
{

    private PoweredState powered { get; set; }
    private List<ConduitPowerableEndpoint> TXs;
    public List<ConduitPowerableEndpoint> permanentConnections;

    void Awake() {
        this.TXs = new List<ConduitPowerableEndpoint>();
    }

    void Update() {
        this.RX();
    }

    public bool isPowered() {
        return this.powered == PoweredState.POWERED;
    }

    public void OnTriggerEntered(Collider other) {
        if (other.GetComponent<ConduitPowerableEndpoint>() != null) {
            this.TXs.Add(other.GetComponent<ConduitPowerableEndpoint>());
        }
    }

    public void OnTriggerExited(Collider other) {
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
        foreach (ConduitPowerableEndpoint endpoint in this.permanentConnections) {
            if (endpoint.isPowered()) {
                result = PoweredState.POWERED;
            }
        }
        this.powered = result;
    }
    
}
