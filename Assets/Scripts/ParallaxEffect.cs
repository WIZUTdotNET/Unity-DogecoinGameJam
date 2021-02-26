using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float smoothing = 1f;

    private Transform[] _backgroundLayers;
    private float[] _parallaxScales;
    private Vector3 _previousCameraPosition;

    private void Start()
    {        
        
        int childCount = GameObject.Find("Background").transform.childCount;
        
        _backgroundLayers = new Transform[childCount - 1];
        
        for (int i = 1; i < childCount; i++)
        {
            _backgroundLayers[i - 1] = GameObject.Find("Background").transform.GetChild(i);
        }
        
        _previousCameraPosition = transform.position;

        _parallaxScales = new float[_backgroundLayers.Length];
        for (var i = 0; i < _backgroundLayers.Length; i++) 
            _parallaxScales[i] = -_backgroundLayers[i].position.z;
    }

    private void Update()
    {
        SetPositionOfEachBackground();
        _previousCameraPosition = transform.position;
    }

    private void SetPositionOfEachBackground()
    {
        for (var i = 0; i < _backgroundLayers.Length; i++)
        {
            var layerPosition = _backgroundLayers[i].position;
            var parallax = (_previousCameraPosition.x - transform.position.x) * _parallaxScales[i];
            var backgroundTargetPositionX = layerPosition.x + parallax;
            var backgroundTargetPosition = new Vector3(backgroundTargetPositionX, layerPosition.y, layerPosition.z);
            _backgroundLayers[i].position =
                Vector3.Lerp(layerPosition, backgroundTargetPosition, smoothing * Time.deltaTime);
        }
    }
}