using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueChecker : PuzzleManager
{
    private int number;

    public void OnPlaquePlaced()
    {
        number++;

    }

    public override bool verifySolved()
    {
        if (number == 3)
        {
            return true;

        }
        return false;
    }
}
