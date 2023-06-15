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
        if (camera.targetTransform==transform)
        {
            camera.MoveToZero();
		}
        else
        {
            camera.MoveToPoint(transform);
        }
    }
}
