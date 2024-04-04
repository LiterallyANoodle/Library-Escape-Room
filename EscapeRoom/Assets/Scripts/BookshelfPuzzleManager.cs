using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[HideInInspector]
public enum State
{
    UNSOLVED,
    SOLVED
}

public class BookshelfPuzzleManager : PuzzleManager
{
    
    private int count;
    [HideInInspector] public State state;
    public BookshelfPuzzleRewardBook rwdBook;

    // Start is called before the first frame update
    void Start()
    {
        state = State.UNSOLVED;
        count = 0;
        // print("Start");
    }

    public void Inc() 
    {
        if (state == State.UNSOLVED)
        {
            count++;
            print("Count: " + count);
            if (count == 3)
            {
                state = State.SOLVED;
                print("Bookshelf_Puzzle: SOLVED");
                rwdBook.DropBook();
            }
        }
    }

    public void Dec() 
    {
        if (state == State.UNSOLVED)
        {
            count--;
            print("Count: " + count);
        }
    }

    
    public override bool verifySolved()
    {
        return (state == State.SOLVED);
    }
}
