using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    private Vector3 targetPosition;

    private void Awake()
    {

    }

    private void Update()
    {
		transform.position = Vector3.Lerp(transform.position, targetPosition + offset, Time.deltaTime * 10);
	}

    public void MoveToPoint(Vector3 targetPos)
    {
        targetPosition = targetPos;
	}

	public void MoveToZero()
	{
        targetPosition = new Vector3(0, 5f, -5f);
	}
}
