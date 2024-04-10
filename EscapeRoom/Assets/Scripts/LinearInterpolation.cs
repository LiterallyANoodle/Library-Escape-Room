using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LinearInterpolation : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform c;
    public Transform d;
    public Transform e;
    public Transform f;

    public int letsMove = 0;
    public int breakCheck = 0;
    public int breakCheck2 = 0;
    public int breakCheck3 = 0;
    public int breakCheck4 = 0;


    public float moveSpeed;
    public Transform current;
    public Transform target;
    private float sinTime;
    // Start is called before the first frame update
    void Start()
    {
        current = a;
        target = b;
        transform.position = current.position;
    }

    public void startScript()
    {
        letsMove = 1;
    }
    // Update is called once per frame
    void Update()
    {
         if (transform.position != target.position & letsMove != 0)
         {
                sinTime += Time.deltaTime * moveSpeed;
                sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
                float t = evaluate(sinTime);
                transform.position = Vector3.Lerp(current.position, target.position, t);
         }
        if(letsMove == 1 & breakCheck == 0)
        {
            continueMove(b, c);
            if(transform.position == target.position)
            {
                print("Yo");
                breakCheck = 1;
                letsMove = 2;
                
            }
        }

        if(letsMove == 2 & breakCheck == 1 & breakCheck2 == 0)
        {      
            continueMove(c, d);
            if (transform.position == target.position)
            {
                print("Hi");
                breakCheck2 = 1;
                letsMove = 3;
                
            }
        }

        if (letsMove == 3 & breakCheck2 == 1 & breakCheck3 == 0)
        {
            continueMove(d, e);
            if (transform.position == target.position)
            {
                breakCheck3 = 1;
                letsMove = 4;
                
            }
        }

        if (letsMove == 4 & breakCheck3 == 1 & breakCheck4 == 0)
        {

            continueMove(e, f);
            if (transform.position == target.position)
            {
                breakCheck4 = 1;
                letsMove = 5;
            
            }
        }
    }

    public void continueMove(Transform start, Transform end)
    {
        if (transform.position != target.position)
        {
            return;
        }
        current = start;
        target = end;
        sinTime = 0;
    }

    public float evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f;
    }
}
