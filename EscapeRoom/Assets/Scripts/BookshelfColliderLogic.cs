using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfColliderLogic : MonoBehaviour
{
    public BookshelfPuzzleManager puzzleManager;
    public GameObject book;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.eulerAngles = new Vector3(270, 270, 0);// (-0.49999997f, -0.50000006f, -0.49999851f, 0.50000155f);
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
