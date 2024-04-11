using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FloatingBookState
{
    GRABBED,
    IDLE
}

public class FloatingBook : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5000;
    private FloatingBookState state;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        state = FloatingBookState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == FloatingBookState.IDLE)
        {
            float multiplier = (Mathf.Sin(Time.time) + speed) / speed;
            // print(multiplier);
            transform.position = new Vector3(transform.position.x, transform.position.y * multiplier, transform.position.z);
            ResetVelocity();
        }
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void ChangeState(int newState)
    {
        if (newState == 0)
        {
            state = FloatingBookState.IDLE;
        }
        else if (newState == 1)
        {
            state = FloatingBookState.GRABBED;
        }
    }    
}
