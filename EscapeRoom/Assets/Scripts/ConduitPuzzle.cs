using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConduitState {

    INACTIVE,
    UNSOLVED,
    SOLVED,

}

public class ConduitPuzzle : PuzzleManager
{

    private ConduitState conduitState;
    public PseudoPowerable powerSource; 
    public GameObject start;
    public GameObject end; 

    // begin in the inactive state until the puzzle is next to be solved. 
    void Awake() {
        this.conduitState = ConduitState.UNSOLVED;
        this.powerSource.powered = PoweredState.POWERED;
    }

    public ConduitState GetState() {
        return this.conduitState;
    }

    public void ProgressState() {
        this.conduitState++;
        if (this.conduitState == ConduitState.SOLVED) {
            print("Solved 1!");
        }
    }

    public override bool VerifySolved()
    {
        return (this.conduitState == ConduitState.SOLVED);
    }

}
