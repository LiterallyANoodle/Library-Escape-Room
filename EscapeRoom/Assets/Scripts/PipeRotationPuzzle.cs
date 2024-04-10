using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;
using static UnityEngine.GraphicsBuffer;


public class PipeRotationPuzzle : PuzzleManager
{
    public Animator animator;

    [SerializeField] private float rotationSpeed = 10f; // Speed of rotation (adjust as needed)
    public GameObject[] objectsToRotate; // Array of objects to rotate

    public int isFirstComplete = 0;
    public int isSecondComplete = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;
    }


    public void rotatePipe(int i)
    {

        objectsToRotate[i].transform.Rotate(Vector3.forward * rotationSpeed); ; // Rotate on X-axis
    
    }


    // Update is called once per frame
    void Update()
    {


        if ((isFirstComplete == 0) && (objectsToRotate[6].transform.eulerAngles.z == 270) && (objectsToRotate[3].transform.eulerAngles.z == 0 | objectsToRotate[3].transform.eulerAngles.z == 180) && (objectsToRotate[0].transform.eulerAngles.z == 90) && (objectsToRotate[1].transform.eulerAngles.z == 90 | objectsToRotate[1].transform.eulerAngles.z == 270) && (objectsToRotate[2].transform.eulerAngles.z == 270) && (objectsToRotate[5].transform.eulerAngles.z == 0 | objectsToRotate[5].transform.eulerAngles.z == 180) && (objectsToRotate[8].transform.eulerAngles.z == 90))
        {
            isFirstComplete = 1;
            animator.enabled = true;
            animator.Play("BallMove");
            print("Congrats");
        }

        if (isFirstComplete == 0)
        {
            float ActivationRandomNumber = UnityEngine.Random.Range(0, 3000);

            if (ActivationRandomNumber == 5)
            {
                int randomPipe = UnityEngine.Random.Range(0, 9);
                objectsToRotate[randomPipe].transform.Rotate(Vector3.forward * rotationSpeed); // Rotate on x-axis
            }
        }

        if (isFirstComplete == 1 && isSecondComplete == 0)
        {
            
            float ActivationRandomNumber = UnityEngine.Random.Range(0, 6);

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
