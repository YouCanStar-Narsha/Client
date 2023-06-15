using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform zero;
    [SerializeField] private Vector3 offset;

    public Transform targetTransform;
    public bool isOn;

    private void Awake()
    {
        MoveToZero();
	}

    private void Update()
    {
        if (isOn)
        {
		    transform.position = Vector3.Lerp(transform.position, targetTransform.position+offset, Time.deltaTime * 10);
        }
        else
        {
			transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * 10);
		}
	}

    public void MoveToPoint(Transform target)
    {
        isOn = true;
		targetTransform = target;
	}

	public void MoveToZero()
	{
        isOn = false;
		targetTransform = zero;
	}
}
