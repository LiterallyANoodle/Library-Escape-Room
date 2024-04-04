using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPuzzle : MonoBehaviour
{
    public GameObject[] pipes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void printInt(int i)
    {
        print(i);
        pipes[i - 1].transform.position += new Vector3(0.5f, 0.5f, 0.5f);
    }
}