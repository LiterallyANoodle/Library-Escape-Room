using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfColliderLogic : MonoBehaviour
{
    // public int book = 1; // 1 = red, 2 = green, 3 = blue
    public BookshelfPuzzleManager puzzleManager;
    public GameObject book;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(book.tag)) 
        { 
            puzzleManager.Inc();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(book.tag))
        {
            puzzleManager.Dec();
        }
    }
}
