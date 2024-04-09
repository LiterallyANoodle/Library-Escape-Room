using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBook : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5000;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // lights.ForEach(light => { light.intensity = ((Mathf.Sin(Time.time) + 1) / 2.0f) * 3; })
        float temp = (Mathf.Sin(Time.time) + speed) / speed;
        print(temp);
        transform.position = new Vector3(transform.position.x, transform.position.y * temp, transform.position.z);
        ResetVelocity();
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
