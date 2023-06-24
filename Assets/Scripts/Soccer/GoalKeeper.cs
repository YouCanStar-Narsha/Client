using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [SerializeField] private float moveSize = 3.5f;
    [SerializeField] private float moveSpeed = 5;

    private int transInt = 1;

    private void Update()
    {
        Move();
	}

    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * transInt * Time.deltaTime;
        if(Mathf.Abs(transform.position.x) >= moveSize)
        {
            transform.position = new Vector3 ((moveSize - 0.05f) * transInt, 0.5f, 2);
            transInt *= -1;
        }
    }
}
