using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    public float smoothing = 1f;

    private Transform[] _backgroundLayers;
    private Transform _ground;
    private GameObject _mainBackground;
    private float[] _parallaxScales;

    private Transform _player;
    private Vector3 _previousCameraPosition;
    private Transform _sky;

    private void Start()
    {
        InitializeGameObjects();
        _previousCameraPosition = transform.position;

        var childCount = _mainBackground.transform.childCount;

        _backgroundLayers = new Transform[childCount - 1];
        _parallaxScales = new float[_backgroundLayers.Length];

        for (var i = 0; i < _backgroundLayers.Length; i++)
        {
            _backgroundLayers[i] = _mainBackground.transform.GetChild(i + 1);
            _parallaxScales[i] = -_backgroundLayers[i].position.z;
        }
    }

    private void Update()
    {
        var playerPositionX = GetTargetXPosition(_player);
        foreach (var backgroundLayer in _backgroundLayers)
        {
            SetBackgroundParallaxPosition(backgroundLayer);
            var backgroundPositionX = backgroundLayer.GetChild(2).position.x;
            if (playerPositionX < backgroundPositionX + .1f && playerPositionX > backgroundPositionX - .1f)
            {
                MoveLayerToRight(backgroundLayer);
                MoveGroundAndSky();
            }
        }

        _previousCameraPosition = transform.position;
    }

    private void InitializeGameObjects()
    {
        _ground = GameObject.Find("Ground").transform;
        _sky = GameObject.Find("BG0_World").transform;
        _player = GameObject.FindWithTag("Player").transform;
        _mainBackground = GameObject.Find("Background");
    }

    private float GetTargetXPosition(Transform target)
    {
        return target.position.x;
    }

    private void MoveLayerToRight(Transform layer)
    {
        var firstLayerPosition = layer.GetChild(0).transform.position;
        var childCount = layer.childCount;
        layer.GetChild(0).transform.position =
            new Vector3(firstLayerPosition.x + 10.24f * childCount, firstLayerPosition.y, firstLayerPosition.z);
        layer.GetChild(0).SetSiblingIndex(childCount);
    }

    private void MoveGroundAndSky()
    {
        _ground.position = new Vector3(transform.position.x, _ground.position.y, _ground.position.z);
        _sky.position = new Vector3(transform.position.x, _sky.position.y, _sky.position.z);
    }

    private void SetBackgroundParallaxPosition(Transform backgroundLayer)
    {
        var layerPosition = backgroundLayer.position;
        var parallax = (_previousCameraPosition.x - transform.position.x) *
                       _parallaxScales[backgroundLayer.GetSiblingIndex() - 1];
        var backgroundTargetPositionX = layerPosition.x + parallax;
        var backgroundTargetPosition = new Vector3(backgroundTargetPositionX, layerPosition.y, layerPosition.z);
        backgroundLayer.position =
            Vector3.Lerp(layerPosition, backgroundTargetPosition, smoothing * Time.deltaTime);
    }
}