using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FoodState
{
    Good,
    Bad
}

public class Food : MonoBehaviour
{
    private FoodState foodState;
    private FoodManager manager;

    [SerializeField] private GameObject eatParticle;
    [SerializeField] private List<GameObject> goodFoodShape = new List<GameObject>();
	[SerializeField] private List<GameObject> badFoodShape = new List<GameObject>();

	private float graviry;
    private float gravityScale = -9.81f * 1.5f;

    private void Awake()
    {
        manager = FindObjectOfType<FoodManager>();
    }

    public void Respawn()
    {
		SetFood();
		graviry = Random.Range(12f, 16f);
        transform.position = new Vector3(0, -1, 6) + (Vector3.right * Random.Range(-3f,3f));
        transform.rotation = Quaternion.identity;
    }

    private void SetFood()
    {
		foodState = Random.Range(0, 1+1) == 0 ? FoodState.Good : FoodState.Bad;
		gameObject.tag = foodState == FoodState.Good ? "Good Food" : "Bad Food";
        if (foodState == FoodState.Good)
        {
            int rand = Random.Range(0, goodFoodShape.Count);
            for (int i = 0; i < goodFoodShape.Count; i++)
            {
                goodFoodShape[i].SetActive(i == rand);
            }
			for (int i = 0; i < badFoodShape.Count; i++)
			{
				badFoodShape[i].SetActive(false);
			}
		}
        else
        {
			int rand = Random.Range(0, badFoodShape.Count);
			for (int i = 0; i < badFoodShape.Count; i++)
			{
				badFoodShape[i].SetActive(i == rand);
			}
			for (int i = 0; i < goodFoodShape.Count; i++)
			{
				goodFoodShape[i].SetActive(false);
			}
		}
	}

    private void Update()
    {
        graviry += gravityScale * Time.deltaTime;

        transform.position += Vector3.up * (graviry * Time.deltaTime);

        if(transform.position.y < -3)
        {
			if (foodState == FoodState.Good)
				manager.score--;
			DestroyFood();
		}
    }

    private void DestroyFood()
    {
        transform.position = new Vector3(0, -1, 0);
		gameObject.SetActive(false);
	}

    private void OnMouseOver()
    {
        if (!Input.GetMouseButton(0)) return;

		ParticleSystem particle = Instantiate(eatParticle, transform.position, Quaternion.Euler(-90, 0, 0)).GetComponent<ParticleSystem>();

		if (foodState == FoodState.Good)
		{
            manager.score++;
            particle.startColor = Color.green;
		}
		else
		{
			manager.score--;
			particle.startColor = Color.red;
		}
        Destroy(particle.gameObject, 2);
		DestroyFood();
	}
}
