using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Camera cam;
    ///<summary>The amount the car's velocity is multiplied by, then added onto the camera's position</summary>
    public float lookAheadMulti = 1.5f;
    public float baseCameraSize = 50f;
    public float viewMulti = 0.25f;
    public float viewSizeCap = 120;
    private void Update()
    {
        if (Car.s != null)
        {
            //TODO: SMOOTH INTERPOLATION OF EACH OF THESE
            //Camera Location
            transform.position = Car.s.transform.position + new Vector3(0, 0, -10) + (Vector3)(Car.s.rb.velocity / lookAheadMulti);
            //Make camera face direction of velocity
            transform.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2(
                    Car.s.rb.velocity.y,
                    Car.s.rb.velocity.x) * Mathf.Rad2Deg - 90f);
            //Dynamic camera zoom depending on car speed
            cam.orthographicSize = Mathf.Min(viewSizeCap, baseCameraSize + (viewMulti * Car.s.rb.velocity.magnitude));
        }
    }
}
