using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour
{
    public Rigidbody2D tireRb;
    public HingeJoint2D joint;
    public Vector2 pos = Vector2.zero;
    Vector2 fricForce = Vector2.zero;
    ///<summary>The friction of the tire on it's side </summary>
    public float staticFriction;
    ///<summary>The friction of the tire on the direction it rolls</summary>
    public float rollingFriction;
    // Start is called before the first frame update
    void Start()
    {
        tireRb = GetComponent<Rigidbody2D>(); 
    }
    public void Accelerate(float acc)
    {
        tireRb.AddRelativeForce(Vector2.up * acc);
        Debug.DrawRay(transform.position, transform.up * acc * Time.fixedDeltaTime, Color.green);
    }
    private void FixedUpdate()
    {
        updateFric();
    }
    public void Steer(float angle)
    {
        tireRb.rotation = angle;
    }
    void updateFric()
    {
        //Vector2 vel = RotateVector(tireRb.velocity, transform.eulerAngles.z);
        Vector2 vel = transform.InverseTransformVector(tireRb.velocity); 
        vel.x *= staticFriction;
        vel.y *= rollingFriction;
        tireRb.AddRelativeForce(-vel, ForceMode2D.Impulse);
        fricForce = transform.TransformVector(-vel);
    }
    public Vector2 RotateVector(Vector2 vec,float angle)
    {
        angle *= Mathf.Deg2Rad;
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);
        return new Vector2((vec.x * cos) - (vec.y * sin), (vec.x * sin) - (vec.y * cos));
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + tireRb.velocity);
        Vector2 vel = RotateVector(tireRb.velocity, transform.eulerAngles.z);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + fricForce);
    }
}
