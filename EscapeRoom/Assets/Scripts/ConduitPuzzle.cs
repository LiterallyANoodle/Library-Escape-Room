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
    public GameObject start;
    public GameObject end; 

    // begin in the inactive state until the puzzle is next to be solved. 
    void Awake() {
        this.conduitState = ConduitState.INACTIVE;
    }

    public ConduitState GetState() {
        return this.conduitState;
    }

    public void ProgressState() {
        this.conduitState++;
    }

    public override bool VerifySolved()
    {
        return (this.conduitState == ConduitState.SOLVED);
    }

}
