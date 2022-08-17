using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Camera cam;
    ///<summary>The amount the car's velocity is multiplied by, then added onto the camera's position</summary>
    public float lookAheadMulti = 1.5f;
    private void Update()
    {
        if (Car.s != null)
        {
            transform.position = Car.s.transform.position + new Vector3(0, 0, -10) + (Vector3)(Car.s.rb.velocity / lookAheadMulti);
            transform.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2(
                    Car.s.rb.velocity.y,
                    Car.s.rb.velocity.x) * Mathf.Rad2Deg - 90f) ;
        }
    }
}
