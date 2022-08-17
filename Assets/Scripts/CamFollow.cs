using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Camera cam;
    private void Update()
    {
        if (Car.s != null) transform.position = Car.s.transform.position + new Vector3(0, 0, -10);
    }
}
