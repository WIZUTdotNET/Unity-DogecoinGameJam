using UnityEngine;

public class RotateAgainst : MonoBehaviour
{
    public GameObject centerOfRotation;
    public float speedOfRotation;
    public int direction = -1;

    private void Update()
    {
        transform.RotateAround(centerOfRotation.transform.position, direction * Vector3.forward,
            speedOfRotation * Time.deltaTime);
    }
}