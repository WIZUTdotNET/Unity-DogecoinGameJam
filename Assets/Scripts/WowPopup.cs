using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WowPopup : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private Transform _transformPosition;
    private float _timer;
    private Color _textColor;
    private Color32[] _colors = new[] { new Color32(255, 0, 0, 255), new Color32(88, 245, 117, 255), 
        new Color32(55, 161, 191, 255), new Color32(243, 7, 250, 255), new Color32(230, 228, 52, 255) };
    private List<string> _sayingsTemplate = new List<string>() { "wow", "much wow", "very wow", "such wow", "cool"};
    
    public static WowPopup Create(Transform transformPosition, Object prefab, string type)
    {
        GameObject wowPopupTransform = (GameObject)Instantiate(prefab, transformPosition.position, Quaternion.identity);
        WowPopup wowPopup = wowPopupTransform.transform.GetComponent<WowPopup>();
        wowPopup.SetUp(transformPosition, type);

        return wowPopup;
    }
    private void Awake()
    {
        _textMeshPro = transform.GetComponent<TextMeshPro>();
        SetUp(transform, "");
    }

    private void SetUp(Transform givenTransform, string type)
    {
        _transformPosition = givenTransform;
        _textMeshPro.faceColor = _colors[Random.Range(0, _colors.Length)];
        _textColor = _textMeshPro.color;
        _sayingsTemplate = _sayingsTemplate.Select(str => string.Concat(str, type)).ToList();
        _textMeshPro.text = _sayingsTemplate[Random.Range(0, _sayingsTemplate.Count)];
        _timer = .3f;
    }

    private void Update()
    {
        transform.position = new Vector3(_transformPosition.position.x, transform.position.y + 5f * Time.deltaTime, transform.position.z);
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _textColor.a -= 3f * Time.deltaTime;
            _textMeshPro.color = _textColor;
            if (_textColor.a < 0)
                Destroy(gameObject);
        }
    }
}
