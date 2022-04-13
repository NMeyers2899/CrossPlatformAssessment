using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraZoomBehavior : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private Vector2 _referenceAspectRatio;
    private Vector3 _startPos;
    private float _refRatio;
    private const float _tolerance = 0.001f;
    [SerializeField]
    private Vector3 _zoomScale = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _refRatio = _referenceAspectRatio.x / _referenceAspectRatio.y;
        _startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        double ratio = _refRatio / _camera.aspect;
        ratio = Math.Round(ratio, 4);

        Vector3 scalePosition = Vector3.Scale(_startPos * (float)ratio, _zoomScale);

        transform.localPosition = scalePosition;
    }
}
