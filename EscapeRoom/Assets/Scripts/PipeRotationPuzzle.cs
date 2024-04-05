using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;


public class PipeRotationPuzzle : PuzzleManager
{
    [SerializeField] private float rotationSpeed = 10f; // Speed of rotation (adjust as needed)
    public GameObject[] objectsToRotate; // Array of objects to rotate

    public int isFirstComplete = 0;
    public int isSecondComplete = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void rotatePipe(int i)
    {

        objectsToRotate[i].transform.Rotate(Vector3.forward * rotationSpeed); ; // Rotate on Y-axis
    
    }



    // Update is called once per frame
    void Update()
    {


        if ((isFirstComplete == 0) && (objectsToRotate[6].transform.eulerAngles.z == 90) && (objectsToRotate[3].transform.eulerAngles.z == 90 | objectsToRotate[3].transform.eulerAngles.z == 270) && (objectsToRotate[0].transform.eulerAngles.z == 180) && (objectsToRotate[1].transform.eulerAngles.z == 0 | objectsToRotate[1].transform.eulerAngles.z == 180) && (objectsToRotate[2].transform.eulerAngles.z == 180) && (objectsToRotate[5].transform.eulerAngles.z == 90 | objectsToRotate[5].transform.eulerAngles.z == 270) && (objectsToRotate[8].transform.eulerAngles.z == 270))
        {
            isFirstComplete = 1;
            print("Congrats");
        }

        if (isFirstComplete == 0)
        {
            float ActivationRandomNumber = UnityEngine.Random.Range(0, 150);

            if (ActivationRandomNumber == 5)
            {
                int randomPipe = UnityEngine.Random.Range(0, 9);
                objectsToRotate[randomPipe].transform.Rotate(Vector3.forward * rotationSpeed); // Rotate on Y-axis
            }
        }

        if (isFirstComplete == 1 && isSecondComplete == 0)
        {
            float ActivationRandomNumber = UnityEngine.Random.Range(0, 80);

            if (ActivationRandomNumber == 5)
            {
                int randomPipe = UnityEngine.Random.Range(9, 25);
                objectsToRotate[randomPipe].transform.Rotate(Vector3.forward * rotationSpeed); // Rotate on Y-axis
            }
        }


    }

    public override bool VerifySolved()
    {
        return isSecondComplete == 1;
    }
}
