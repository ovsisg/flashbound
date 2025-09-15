using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Camera mainCamera;

    private float previousCameraPositionX;
    private float cameraHalfWidth;

    [SerializeField] private ParallaxLayer[] parallaxLayers;

    private void Awake()
    {
        mainCamera = Camera.main;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        InitialiseLayerWidths();
    }

    private void FixedUpdate()
    {
        float currentCameraPositionX = mainCamera.transform.position.x;
        float distanceToMove = currentCameraPositionX - previousCameraPositionX;
        previousCameraPositionX = currentCameraPositionX;

        float cameraLeftEdge = currentCameraPositionX - cameraHalfWidth;
        float cameraRightEdge = currentCameraPositionX + cameraHalfWidth;

        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.ApplyParallaxMovement(distanceToMove);
            layer.LoopIfOutOfView(cameraLeftEdge, cameraRightEdge);
        }
    }

    private void InitialiseLayerWidths()
    {
        foreach (ParallaxLayer layer in parallaxLayers)
            layer.InitialiseImageWidth();
    }
}
