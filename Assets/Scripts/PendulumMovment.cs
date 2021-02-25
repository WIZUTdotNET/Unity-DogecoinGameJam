using Unity.Mathematics;
using UnityEngine;


public class PendulumMovment : MonoBehaviour
{
    public GameObject centerOfRotation;

    public float speedOfPendulum;
    public float swingOffset;
    public float swingAngle;
    public int directionOfSwing = 1;

    private float _angleSum;
    private float _actualAngle;

    private void Update()
    {
        _actualAngle = speedOfPendulum * Time.deltaTime;

        Swing();

        if (_angleSum > 360)
            _angleSum -= 360;

        if (_angleSum < -360)
            _angleSum += 360;
    }

    private void Swing()
    {
        transform.RotateAround(centerOfRotation.transform.position, directionOfSwing * Vector3.forward,
            _actualAngle);

        _angleSum += directionOfSwing * _actualAngle;
        if (math.abs(_angleSum + swingOffset) > swingAngle)
            directionOfSwing *= -1;
    }
}