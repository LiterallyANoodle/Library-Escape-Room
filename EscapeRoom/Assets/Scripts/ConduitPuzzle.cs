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

    // begin in the inactive state until the puzzle is next to be solved. 
    void Awake() {
        this.conduitState = ConduitState.INACTIVE;
    }

    public ConduitState GetState() {
        return this.conduitState;
    }

    public void ProgressState() {
        if (this.conduitState == ConduitState.INACTIVE) {
            this.conduitState = ConduitState.UNSOLVED;
        } else if (this.conduitState == ConduitState.UNSOLVED) {
            this.conduitState = ConduitState.SOLVED;
        }
    }

    public override bool VerifySolved()
    {
        return (this.conduitState == ConduitState.SOLVED);
    }

}
