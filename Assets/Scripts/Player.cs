using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //The input of the player
    public Vector2 input = Vector2.zero;
    //The car instance controlled by the player
    public Car controller;
    //Ratio of what portion of the screen controls the car
    public Vector2 controlRatio;
    public Image visual;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (controller != null)
        {
            controller.Accelerate(input.y);
            controller.Steer(input.x);
        }
        if (visual != null)
        {
            
        }
    }
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
