using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;
    private float speed = 2f;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        var cameraPosition = Vector3.Lerp(transform.position, new Vector3(_target.position.x, 0, transform.position.z),
            speed * Time.fixedDeltaTime);
        transform.position = cameraPosition;
        speed = _target.GetComponent<PlayerMovement>().speed;
    }
}