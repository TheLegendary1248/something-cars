using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script that controls the behaviour of an entire car
/// </summary>
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
    // Start is called before the first frame update
    void Start()
    {
        s = this;
    }
    public void Steer(float steer)
    {
        steer *= maxSteerAngle;
        tires[0].Steer(transform.eulerAngles.z - steer);
        tires[1].Steer(transform.eulerAngles.z - steer);
    }
    /// <summary>
    /// Accelerate the car forward by it's power times the given input, clamped 0-1
    /// </summary>
    /// <param name="i"></param>
    public void Accelerate(float acc)
    {
        acc *= acceleration;
        tires[2].Accelerate(acc);
        tires[3].Accelerate(acc);
    }
    void updateFric()
    {
        rb.AddForce(getLateralVelocity());
    }
    Vector2 getLateralVelocity() => Vector2.Dot(transform.right, rb.velocity) * transform.right;
    // Update is called once per frame

}
