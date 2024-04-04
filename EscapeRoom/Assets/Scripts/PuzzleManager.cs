using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    private List<PuzzleManager> subPuzzles;

    // Start is called before the first frame update
    void Start()
    {
        this.subPuzzles = new List<PuzzleManager>();
    }

    // add sub puzzle managers
    public void addSubPuzzle(PuzzleManager puzzle) {
        this.subPuzzles.Add(puzzle);
    }

    // Verify puzzle is solved 
    public virtual bool verifySolved() {
        bool result = true;
        foreach (PuzzleManager puzzle in this.subPuzzles) {
            result = result && puzzle.verifySolved();
        }
        return result;
    }

}
