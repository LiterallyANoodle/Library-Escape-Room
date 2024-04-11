using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueChecker : PuzzleManager
{
    private int number;

    public void OnPlaquePlaced()
    {
        number++;
        print(number);
    }

    public override bool VerifySolved()
    {
        if (number >= 2)
        {
            print("Statue Solved");
            return true;
        }
        return false;
    }
}
