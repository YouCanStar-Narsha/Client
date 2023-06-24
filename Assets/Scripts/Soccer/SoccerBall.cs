using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private bool isTraking;
    private bool isShot;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        TryTraking();
		if (rigid.velocity.magnitude < 0.5f && isShot)
		{
    		ResetBall();
		}
	}

    private void FixedUpdate()
    {
        Traking();
    }

    private void ResetBall()
    {
		isShot = false;
        rigid.velocity = Vector3.zero;
		transform.position = new Vector3(0, 0.3f, -3.5f);
	}

    private void TryTraking()
    {
        if (Input.GetMouseButton(0))
        {
			if (isShot) return;

			isTraking = true;
		}
        else
        {
            isTraking = false;
            TryShot();
		}
    }

    private void TryShot()
    {
        if (isShot) return;

        Shot();
        isShot = true;
    }

    private void Traking()
    {
        if (isTraking)
        {
            float set = 0.15f;

            Vector3 offset = new Vector3(0, 0, -3.5f);

			Vector3 dir = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            dir.x -= 0.5f;
            dir.x *= 9;
			dir.y *= 16;
            rigid.velocity = ((((dir + Vector3.up) * set) + offset) - transform.position) * 15;
		}
    }

    private void Shot()
    {
        print("½¸");
        rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y * 0.22f, rigid.velocity.y * 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            other.transform.parent.GetComponent<GoalPost>().Goal();
            ResetBall();
        }
    }
}
