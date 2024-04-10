using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.ProBuilder.Shapes;


public class PipeRotationPuzzle : PuzzleManager
{
    public Animator animator;
    [SerializeField] private float rotationSpeed = 10f; // Speed of rotation (adjust as needed)
    public GameObject[] objectsToRotate; // Array of objects to rotate
    public GameObject testSphere = null;
    public int isFirstComplete = 0;
    public int isSecondComplete = 0;


    // Start is called before the first frame update
    void Start()
    {
        testSphere = GameObject.FindWithTag("TestSphere");
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

        //Stop animation because we need to solve the second one
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > .5f && isFirstComplete == 1 && isSecondComplete == 0)
        {
            animator.speed = 0;
        }

        //Start animation again
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > .5f && isFirstComplete == 1 && isSecondComplete == 1)
        {
            animator.speed = 1;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > .99f && isFirstComplete == 1 && isSecondComplete == 1)
        {
            Sphere sphere = new Sphere();
            animator.speed = 0;
            Destroy(animator.gameObject);           
            testSphere.transform.position = new Vector3(10.0819998f, -0.236999989f, -0.343999863f);

        }



        if (isFirstComplete == 1 && isSecondComplete == 0)
        {

            float ActivationRandomNumber = UnityEngine.Random.Range(0, 500);

            if (ActivationRandomNumber == 5)
            {
                int randomPipe = UnityEngine.Random.Range(9, 25);
                objectsToRotate[randomPipe].transform.Rotate(Vector3.forward * rotationSpeed); // Rotate on Y-axis
            }
        }
        if (isFirstComplete == 1 && isSecondComplete == 0 && (objectsToRotate[21].transform.eulerAngles.z == 0 | objectsToRotate[21].transform.eulerAngles.z == 180) && (objectsToRotate[22].transform.eulerAngles.z == 180) && (objectsToRotate[18].transform.eulerAngles.z == 90 | objectsToRotate[18].transform.eulerAngles.z == 270) && (objectsToRotate[14].transform.eulerAngles.z == 90) && (objectsToRotate[13].transform.eulerAngles.z == 0) && (objectsToRotate[14].transform.eulerAngles.z == 90) && (objectsToRotate[9].transform.eulerAngles.z == 180) && (objectsToRotate[10].transform.eulerAngles.z == 90 | objectsToRotate[10].transform.eulerAngles.z == 270) && (objectsToRotate[11].transform.eulerAngles.z == 0 | objectsToRotate[11].transform.eulerAngles.z == 180) && (objectsToRotate[12].transform.eulerAngles.z == 90) && (objectsToRotate[16].transform.eulerAngles.z == 0 | objectsToRotate[16].transform.eulerAngles.z == 180) && (objectsToRotate[20].transform.eulerAngles.z == 0 | objectsToRotate[20].transform.eulerAngles.z == 180) && (objectsToRotate[24].transform.eulerAngles.z == 270))
        {
            isSecondComplete = 1;
            print("Congrats 2");

        }
    }
    public override bool VerifySolved()
    {
        return isSecondComplete == 1;
    }
}
