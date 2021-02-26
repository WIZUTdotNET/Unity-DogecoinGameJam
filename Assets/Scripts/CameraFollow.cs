using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _speed = 2f;
    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        var cameraPosition = Vector3.Lerp(transform.position, new Vector3(_target.position.x, 0, transform.position.z),
            _speed * Time.fixedDeltaTime);
        transform.position = cameraPosition;
        _speed = _target.GetComponent<PlayerMovement>().speed;
    }
}