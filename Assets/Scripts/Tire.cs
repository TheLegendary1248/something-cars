using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour
{
    public Rigidbody2D carRb;
    // Start is called before the first frame update
    void Start()
    {
        carRb = transform.parent.GetComponent<Rigidbody2D>(); 
    }
    public void Accelerate(float acc)
    {
        carRb.AddForceAtPosition(Vector2.up * acc, transform.position);
    }
    private void FixedUpdate()
    {
        updateFric();
    }
    void updateFric()
    {
        carRb.AddForce(-getLateralVelocity());
    }
    Vector2 getLateralVelocity() => Vector2.Dot(transform.right, carRb.velocity) * transform.right;

    // Update is called once per frame
    void Update()
    {
        
    }
}
