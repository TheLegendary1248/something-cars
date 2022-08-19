using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Tire[] tires = new Tire[] { };
    public static Car s;
    public float acceleration;
    public float maxSteerAngle;
    ///<summary>The friction of the tire on </summary>
    public float staticFriction;
    ///<summary>The friction of the tire on the direction it rolls</summary>
    public float rollingFriction;
    public Rigidbody2D rb;
    public Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        s = this;
    }
    private void FixedUpdate()
    {
        float steer = maxSteerAngle * -input.x;
        tires[0].transform.eulerAngles = Vector3.forward * steer;
        tires[1].transform.eulerAngles = Vector3.forward * steer;
        tires[2].Accelerate(input.y * acceleration);
        tires[3].Accelerate(input.y * acceleration);
        //Translated tutorial code

        //
        //Added code

        /*
        
        //Acceleration
        rb.velocity += (Vector2)transform.up * Time.fixedDeltaTime * acceleration * input.y * rollingFriction;
        Vector2 vel = rb.velocity;
        //Steer
        //Rotate our velocity first
        float cos = Mathf.Cos(Mathf.Rad2Deg * steer); 
        float sin = Mathf.Sin(Mathf.Rad2Deg * steer);
        Vector2 rotated = new Vector2((vel.x * cos) - (vel.y * sin), (vel.x * sin) - (vel.y * cos));
        rb.velocity += rotated * staticFriction * Time.fixedDeltaTime;
        transform.Rotate(transform.forward, rotated.magnitude * steer * rollingFriction * Time.fixedDeltaTime);
        rb.velocity -= rb.velocity * rollingFriction * Time.fixedDeltaTime;
        */
    }

    void updateFric()
    {
        rb.AddForce(getLateralVelocity());
    }
    Vector2 getLateralVelocity() => Vector2.Dot(transform.right, rb.velocity) * transform.right;
    // Update is called once per frame
    void Update()
    {
        Vector2 centered = Input.mousePosition / new Vector2(Screen.width, Screen.height);
        centered -= new Vector2(0.5f, 0.5f);
        centered *= 4f;
        centered.x = Mathf.Clamp(centered.x, -1f, 1f);
        centered.y = Mathf.Clamp(centered.y, -1f, 1f);
        input = centered;
    }
}
