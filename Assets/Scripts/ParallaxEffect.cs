using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform[] backgroundLayers;
    public float smoothing = 1f;

    private float[] _parallaxScales;
    private Vector3 _previousCameraPosition;

    private void Start()
    {
        _previousCameraPosition = transform.position;

        _parallaxScales = new float[backgroundLayers.Length];
        for (var i = 0; i < backgroundLayers.Length; i++) 
            _parallaxScales[i] = -backgroundLayers[i].position.z;
    }

    private void Update()
    {
        SetPositionOfEachBackground();
        _previousCameraPosition = transform.position;
    }

    private void SetPositionOfEachBackground()
    {
        for (var i = 0; i < backgroundLayers.Length; i++)
        {
            var layerPosition = backgroundLayers[i].position;
            var parallax = (_previousCameraPosition.x - transform.position.x) * _parallaxScales[i];
            var backgroundTargetPositionX = layerPosition.x + parallax;
            var backgroundTargetPosition = new Vector3(backgroundTargetPositionX, layerPosition.y, layerPosition.z);
            backgroundLayers[i].position =
                Vector3.Lerp(layerPosition, backgroundTargetPosition, smoothing * Time.deltaTime);
        }
    }
}