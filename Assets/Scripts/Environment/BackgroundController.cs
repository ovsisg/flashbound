using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float initialPositionX;
    private float backgroundLength;

    [Header("Camera & Parallax")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float parallaxEffect = 0.5f;

    private void Start()
    {
        initialPositionX = transform.position.x;
        backgroundLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float parallaxDistance = cameraTransform.position.x * parallaxEffect;
        float cameraDistance = cameraTransform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(initialPositionX + parallaxDistance, transform.position.y, transform.position.z);

        if (cameraDistance > initialPositionX + backgroundLength)
            initialPositionX += backgroundLength;
        else if (cameraDistance < initialPositionX - backgroundLength)
            initialPositionX -= backgroundLength;
    }
}
