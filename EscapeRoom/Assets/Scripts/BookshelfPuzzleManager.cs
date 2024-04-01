using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum State
{
    UNSOLVED,
    SOLVED
}

public class BookshelfPuzzleManager : MonoBehaviour
{
    
    private int count;
    public State state;
    public BookshelfPuzzleRewardBook rwdBook;

    // Start is called before the first frame update
    void Start()
    {
        state = State.UNSOLVED;
        count = 0;
        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
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
                print("SOLVED");
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
}
