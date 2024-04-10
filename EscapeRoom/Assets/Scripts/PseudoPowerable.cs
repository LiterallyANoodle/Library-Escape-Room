using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoweredState {
    UNPOWERED,
    POWERED,
}

public class PseudoPowerable : MonoBehaviour {

    public PoweredState powered { get; set; }
    public bool isRecvFromPermanentConnections { get; set; }

    public PseudoPowerable() {
        this.powered = PoweredState.UNPOWERED;
        this.isRecvFromPermanentConnections = false;
    }

    public PseudoPowerable(PoweredState powered) {
        this.powered = powered;
        this.isRecvFromPermanentConnections = false;
    }

    public bool isPowered() {
        return this.powered == PoweredState.POWERED;
    }

}