using TMPro;
using UnityEngine;

public class WowPopup : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private Transform _transformPosition;
    private float _timer;
    private Color _textColor;

    public static WowPopup Create(Transform transformPosition, Transform prefab)
    {
        Transform wowPopupTransform = Instantiate(prefab, transformPosition.position, Quaternion.identity);
        WowPopup wowPopup = wowPopupTransform.GetComponent<WowPopup>();
        wowPopup.SetUp(transformPosition);

        return wowPopup;
    }
    private void Awake()
    {
        _textMeshPro = transform.GetComponent<TextMeshPro>();
        SetUp(transform);
    }

    private void SetUp(Transform givenTransform)
    {
        _transformPosition = givenTransform;
        _textColor = _textMeshPro.color;
        _textMeshPro.text = "wow";
        _timer = .3f;
    }

    private void Update()
    {
        transform.position = new Vector3(_transformPosition.position.x, transform.position.y + 8f * Time.deltaTime, transform.position.z);
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
