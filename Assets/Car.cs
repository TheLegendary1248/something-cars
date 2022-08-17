using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float acceleration;
    public float turnSpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.up * 20f;
    }
    private void FixedUpdate()
    {
        transform.Rotate(transform.forward, turnSpeed * -Input.GetAxis("Horizontal") * Time.fixedDeltaTime);
        rb.velocity += (Vector2)transform.up * Time.fixedDeltaTime * acceleration * Input.GetAxis("Vertical");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
