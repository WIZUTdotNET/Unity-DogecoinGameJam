using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 cameraPosition = Vector3.Lerp(transform.position, new Vector3(_target.position.x, 0, transform.position.z), Time.fixedDeltaTime);
        transform.position = cameraPosition;
    }
}
