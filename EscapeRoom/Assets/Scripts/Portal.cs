using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Game game;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        // print(other.tag);
        if (other.CompareTag("Player"))
        {
            game.SetWin();
        }
    }
}
