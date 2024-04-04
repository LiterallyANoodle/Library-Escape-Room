using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;
public class PipeRotationPuzzle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f; // Speed of rotation (adjust as needed)
    public GameObject[] objectsToRotate; // Array of objects to rotate
    // Start is called before the first frame update
    void Start()
    {
        print("hello");
    }


    public void rotatePipe(int i)
    {

        objectsToRotate[i].transform.Rotate(Vector3.forward * rotationSpeed); ; // Rotate on Y-axis
    
    }



    // Update is called once per frame
    void Update()
    {
        float ActivationRandomNumber = UnityEngine.Random.Range(0, 100);

        if(ActivationRandomNumber == 5)
        {
            int randomPipe = UnityEngine.Random.Range(0, 9);
            objectsToRotate[randomPipe].transform.Rotate(Vector3.forward * rotationSpeed); ; // Rotate on Y-axis
        }


    }

}
