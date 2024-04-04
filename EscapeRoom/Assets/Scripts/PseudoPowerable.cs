using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoweredState {
    UNPOWERED,
    POWERED,
}

public class PseudoPowerable : MonoBehaviour {

    public PoweredState powered { get; set; }

    public PseudoPowerable() {
        this.powered = PoweredState.UNPOWERED;
    }

    public PseudoPowerable(PoweredState powered) {
        this.powered = powered;
    }

    public bool isPowered() {
        return this.powered == PoweredState.POWERED;
    }

}