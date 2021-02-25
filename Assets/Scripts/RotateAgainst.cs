using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAgainst : MonoBehaviour
{
    public GameObject centerOfRotation;
    public float speedOfRotation;
    void Update()
    {
        transform.RotateAround(centerOfRotation.transform.position, -Vector3.forward, speedOfRotation * Time.deltaTime);
    }
}
