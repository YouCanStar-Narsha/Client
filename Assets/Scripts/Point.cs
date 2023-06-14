using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private CameraController camera;

    private void Awake()
    {
        camera = Camera.main.GetComponent<CameraController>();
    }

    private void OnMouseDown()
    {
        camera.MoveToPoint(transform.position);
    }
}
