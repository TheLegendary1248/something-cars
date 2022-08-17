using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car s;
    public float acceleration;
    public float turnSpeed;
    public Rigidbody2D rb;
    public Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        s = this;
        rb.velocity = Vector2.up * 20f;
    }
    private void FixedUpdate()
    {
        transform.Rotate(transform.forward, turnSpeed * -input.x * Time.fixedDeltaTime);
        rb.velocity += (Vector2)transform.up * Time.fixedDeltaTime * acceleration * input.y;

    }

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
