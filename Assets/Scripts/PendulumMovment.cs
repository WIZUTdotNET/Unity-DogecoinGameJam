using Unity.Mathematics;
using UnityEngine;

public class PendulumMovment : MonoBehaviour
{
    public GameObject centerOfRotation;

    public float speedOfPendulum;
    public float swingOffset;
    public float swingAngle;
    public int directionOfSwing = 1;
    private float _actualAngle;

    private float _angleSum;

    private void Update()
    {
        Swing();
        FixAngle();
    }

    private void Swing()
    {
        _actualAngle = speedOfPendulum * Time.deltaTime;

        transform.RotateAround(centerOfRotation.transform.position, directionOfSwing * Vector3.forward,
            _actualAngle);

        _angleSum += directionOfSwing * _actualAngle;
        if (math.abs(_angleSum + swingOffset) > swingAngle)
            directionOfSwing *= -1;
    }

    private void FixAngle()
    {
        if (_angleSum > 360)
            _angleSum -= 360;

        if (_angleSum < -360)
            _angleSum += 360;
    }
}