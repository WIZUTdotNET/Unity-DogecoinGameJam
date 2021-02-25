﻿using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;

    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        var sprite = GetComponent<SpriteRenderer>().sprite;
        var texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,
            deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - cameraTransform.position.x) >= textureUnitSizeX)
        {
            var offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            cameraTransform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }

        //if (Mathf.Abs(cameraTransform.position.x - cameraTransform.position.x) >= textureUnitSizeX)
        //{
        //    float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
        //    cameraTransform.position = new Vector3(transform.position.y,cameraTransform.position.y + offsetPositionY);
        //}
    }
}