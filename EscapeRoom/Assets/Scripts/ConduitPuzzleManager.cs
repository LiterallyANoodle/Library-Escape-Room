using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConduitPuzzleManagerState {

    NONE,
    ONE,
    TWO,
    THREE,

}

public class ConduitPuzzleManager : PuzzleManager
{
    
    private ConduitPuzzleManagerState state;

    void Awake() {
        this.state = ConduitPuzzleManagerState.NONE;
        this.AddSubPuzzle(new ConduitPuzzle());
        this.AddSubPuzzle(new ConduitPuzzle());
        this.AddSubPuzzle(new ConduitPuzzle());
    }

    public void ProgressState() {
        this.state++;
    }

    public override bool VerifySolved()
    {
        return (this.state == ConduitPuzzleManagerState.THREE);
    }

}
