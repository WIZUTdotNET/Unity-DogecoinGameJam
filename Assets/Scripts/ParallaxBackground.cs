using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Transform _cameraTransform;
    private Vector3 _lastCameraPosition;
    private float _textureUnitSizeX;
    private float _textureUnitSizeY;

    // Start is called before the first frame update
    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraPosition = _cameraTransform.position;
        var sprite = GetComponent<SpriteRenderer>().sprite;
        var texture = sprite.texture;
        _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        _textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var deltaMovement = _cameraTransform.position - _lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,
            deltaMovement.y * parallaxEffectMultiplier.y);
        _lastCameraPosition = _cameraTransform.position;

        if (Mathf.Abs(_cameraTransform.position.x - _cameraTransform.position.x) >= _textureUnitSizeX)
        {
            var offsetPositionX = (_cameraTransform.position.x - transform.position.x) % _textureUnitSizeX;
            _cameraTransform.position =
                new Vector3(_cameraTransform.position.x + offsetPositionX, transform.position.y);
        }

        //if (Mathf.Abs(cameraTransform.position.x - cameraTransform.position.x) >= textureUnitSizeX)
        //{
        //    float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
        //    cameraTransform.position = new Vector3(transform.position.y,cameraTransform.position.y + offsetPositionY);
        //}
    }
}